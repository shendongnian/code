    public class Settings {
       private WordsLicense wlic;
       private PdfLicence plic;
        public static T GetLicense<T>() where T : class
        {
            if (typeof(T) == typeof(WordsLicense)) { if (wlic == null) wlic = new WordsLicense(); return wlic as T; }
            if (typeof(T) == typeof(PdfLicence)) { if (plic == null) plic = new PdfLicence(); return plic as T; }
            return null;
        }   
    }
