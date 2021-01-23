    public class Credentials : ICryptographerUser {
        public string ProfileName { get; set; }
        internal string _secretKey { get; set; }
        internal string _accessKey { get; set; }
        public string SecretKey { get; set; }
        public string AccessKey {
            get { return _accessKey; }
            private set { _accessKey = value; }
        }
        public string AccessKeyDecrypted {
            get { return Cryptographer.Decrypt(_accessKey); }
        }
        public void SetAccessKey(string value) {
            _accessKey = Cryptographer.Encrypt(value);
        }
        public ICryptographer Cryptographer { get; set; }
    }
