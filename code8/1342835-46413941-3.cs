    [System.Serializable]
    public class QrCodeResult
    {
        public QRCodeData[] result;
    }
    
    [System.Serializable]
    public class Symbol
    {
        public int seq;
        public string data;
        public string error;
    }
    
    [System.Serializable]
    public class QRCodeData
    {
        public string type;
        public Symbol[] symbol;
    }
 
