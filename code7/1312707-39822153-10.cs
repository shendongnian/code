    namespace BouncyJWT
    {
    
    
        public class JwtKey
        {
            public byte[] MacKeyBytes;
            public Org.BouncyCastle.Crypto.AsymmetricKeyParameter RsaPrivateKey;
            public Org.BouncyCastle.Crypto.Parameters.ECPrivateKeyParameters EcPrivateKey;
    
    
            public string MacKey
            {
                get { return System.Text.Encoding.UTF8.GetString(this.MacKeyBytes); }
                set { this.MacKeyBytes = System.Text.Encoding.UTF8.GetBytes(value); }
            }
    
    
            public JwtKey()
            { }
    
            public JwtKey(string macKey)
            {
                this.MacKey = macKey;
            }
    
            public JwtKey(byte[] macKey)
            {
                this.MacKeyBytes = macKey;
            }
    
            public JwtKey(Org.BouncyCastle.Crypto.AsymmetricKeyParameter rsaPrivateKey)
            {
                this.RsaPrivateKey = rsaPrivateKey;
            }
    
            public JwtKey(Org.BouncyCastle.Crypto.Parameters.ECPrivateKeyParameters ecPrivateKey)
            {
                this.EcPrivateKey = ecPrivateKey;
            }
        }
    
    
    }
