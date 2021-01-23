    internal class CFingerPrint
    {
        public string WanIP;
        public string MacAddress;      
    
        public string getClassEncrypted()
        {
            return new JavaScriptSerializer().Serialize(this);
        }
    
        public CFingerPrint getClassDecrypted(string sSerializedClass)
        {
            return new JavaScriptSerializer().Deserialize<CFingerPrint>(sSerializedClass);
        }
    }
