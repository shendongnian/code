    /*
        using Org.BouncyCastle.Crypto;
    */
    
    public class CARequestModel
    {
        public AsymmetricKeyParameter PrivateKey { get; set; }
        public string Request { get; set; }
    }
