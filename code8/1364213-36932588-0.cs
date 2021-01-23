    using System.Security.Cryptography;
    using System.Text;
    
    namespace SignatureDemo
    {
        public class Demo
        {
            static void Main(string[] args)
            {
                // "Main" is from the client point of view
                LicenseServer server = new LicenseServer();
                Signer signer = new Signer();
    
                // Obtain a key from the server
                LicenseKey key = server.GetKey("nodots");
    
                // Verify the signature of the unchanged key, this will result to true
                bool isValid1 = signer.VerifySignature(key, server.PublicKey);
    
                // Manipulate the license
                key.License.FeatureB = true;
    
                // Verify the signature of the changed key, this will result to false
                bool isValid2 = signer.VerifySignature(key, server.PublicKey);
            }
        }
    
        public class LicenseServer
        {
            // Contains both public and private key. This must stay secret!
            private readonly string _keyPair;
    
            private readonly Signer _signer = new Signer();
    
            public LicenseServer()
            {
                // Create demo key pair
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    _keyPair = rsa.ToXmlString(true);
                    PublicKey = rsa.ToXmlString(false);
                }
            }    
    
            public string PublicKey
            {
                get;
            }
    
            public LicenseKey GetKey(string customerName)
            {
                LicenseKey key = new LicenseKey(new License(customerName, true, false));
                key.Signature = _signer.CreateSignature(key, _keyPair);
    
                return key;
            }
        }
    
        public class LicenseKey
        {
            public LicenseKey(License license)
            {
                License = license;
            }
    
            public License License
            {
                get;
                set;
            }
    
            public byte[] Signature
            {
                get;
                set;
            }
        }
    
        public class License
        {
            public License(string customerName, bool featureA, bool featureB)
            {
                CustomerName = customerName;
                FeatureA = featureA;
                FeatureB = featureB;
            }
    
            public string CustomerName
            {
                get;
                set;
            }
    
            public bool FeatureA
            {
                get;
                set;
            }
    
            public bool FeatureB
            {
                get;
                set;
            }
        }
    
        public class Signer
        {
            public byte[] CreateSignature(LicenseKey key, string privateKey)
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(privateKey);
                    return rsa.SignData(ComputeHash(key), CryptoConfig.MapNameToOID("SHA256"));
                }
            }
    
            public bool VerifySignature(LicenseKey key, string publicKey)
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(publicKey);
                    return rsa.VerifyData(ComputeHash(key), CryptoConfig.MapNameToOID("SHA256"), key.Signature);
                }
            }
    
            private static byte[] ComputeHash(LicenseKey key)
            {
                // Create a hash from the given key. 
                // For demo purposes I'm using a very simple string concatenation of the relevant properties.
    
                string simplifiedHash = string.Concat(key.License.CustomerName, key.License.FeatureA, key.License.FeatureB);
                return Encoding.UTF8.GetBytes(simplifiedHash);
            }
        }
    }
