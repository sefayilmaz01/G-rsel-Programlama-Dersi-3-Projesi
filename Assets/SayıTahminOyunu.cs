using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SayiTahminOyunu : MonoBehaviour
{
    public GameObject tahminInputNesnesi;
    public GameObject sonucYazisiNesnesi;

    private int gizliSayi;
    private int kalanHak; 

    void Start()
    {
        OyunuYenidenBaslat();
    }

    public void OyunuYenidenBaslat()
    {
        gizliSayi = Random.Range(1, 21);
        kalanHak = 5;

        YaziMetniniAyarla("1 ile 20 arasında bir sayı tuttum.\nToplam 5 hakkın var. Tahmin et!");
        InputTemizle();
    }

    public void TahminKontrolEt()
    {
        Debug.Log("Butona başarıyla basıldı!");
        string inputMetni = InputMetniniAl();

        if (int.TryParse(inputMetni, out int oyuncuTahmini))
        {
            if (oyuncuTahmini < 1 || oyuncuTahmini > 20)
            {
                YaziMetniniAyarla("Lütfen 1 ile 20 arasında bir sayı girin!\nHakkın eksilmedi, kalan hak: " + kalanHak);
                InputTemizle();
                return;
            }

            
            if (oyuncuTahmini == gizliSayi)
            {
                YaziMetniniAyarla("🎉 Tebrikler! Doğru tahmin: " + gizliSayi + "\nYeni oyun başlıyor...");
             
                Invoke("OyunuYenidenBaslat", 2.0f);
            }
            else 
            {
                kalanHak--; 

                if (kalanHak > 0)
                {
                    string ipucu = oyuncuTahmini < gizliSayi ? "Daha BÜYÜK ⬆️" : "Daha KÜÇÜK ⬇️";
                    YaziMetniniAyarla(ipucu + "\nKalan Hakkın: " + kalanHak);
                }
                else
                {
                    
                    YaziMetniniAyarla("💥 Kaybettin! Tuttuğum sayı: " + gizliSayi + "\nYeniden deneniyor...");
                    
                    Invoke("OyunuYenidenBaslat", 2.0f);
                }
            }
        }
        else
        {
            YaziMetniniAyarla("Lütfen geçerli bir sayı giriniz!\nKalan hak: " + kalanHak);
        }

        InputTemizle();
    }

   
    void YaziMetniniAyarla(string mesaj)
    {
        if (sonucYazisiNesnesi.GetComponent<Text>() != null)
            sonucYazisiNesnesi.GetComponent<Text>().text = mesaj;
        else if (sonucYazisiNesnesi.GetComponent<TextMeshProUGUI>() != null)
            sonucYazisiNesnesi.GetComponent<TextMeshProUGUI>().text = mesaj;
    }

    string InputMetniniAl()
    {
        if (tahminInputNesnesi.GetComponent<InputField>() != null)
            return tahminInputNesnesi.GetComponent<InputField>().text;
        else if (tahminInputNesnesi.GetComponent<TMP_InputField>() != null)
            return tahminInputNesnesi.GetComponent<TMP_InputField>().text;
        return "";
    }

    void InputTemizle()
    {
        if (tahminInputNesnesi.GetComponent<InputField>() != null)
        {
            tahminInputNesnesi.GetComponent<InputField>().text = "";
            tahminInputNesnesi.GetComponent<InputField>().ActivateInputField();
        }
        else if (tahminInputNesnesi.GetComponent<TMP_InputField>() != null)
        {
            tahminInputNesnesi.GetComponent<TMP_InputField>().text = "";
            tahminInputNesnesi.GetComponent<TMP_InputField>().ActivateInputField();
        }
    }
}