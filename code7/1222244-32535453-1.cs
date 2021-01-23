        public class Signer
    {
        public string appId = getApkId();
        public string appSecret = getAppSecret();
        public string servicio = "";
        public string sessionToken = "";
        public string timestamp = "";
        public string requestId = "";
        public string params = "";
    
        //Here I have to write the getParamsAsStr()
    
        private static string getApkId(){
            string id = "xxxxxxxxxxxxxxxx";
            return id;
        }
    
        private static string getAppSecret(){
            string id = "xxxxxxxxxxxxxxxx";
            return id;
        }
    }
