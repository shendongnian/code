    private string Encrypt(string pPublicKey, string pInputString)
        {
            //Create a new instance of the RSACryptoServiceProvider class.
            RSACryptoServiceProvider lRSA = new RSACryptoServiceProvider();
            //Import key parameters into RSA.
            lRSA.ImportParameters(GetRSAParameters(pPublicKey));
            return Convert.ToBase64String(lRSA.Encrypt(Encoding.UTF8.GetBytes(pInputString), false));
        }
        private static RSAParameters GetRSAParameters(string pPublicKey)
        {
            byte[] lDer;
            //Set RSAKeyInfo to the public key values. 
            int lBeginStart = "-----BEGIN PUBLIC KEY-----".Length;
            int lEndLenght = "-----END PUBLIC KEY-----".Length;
            string KeyString = pPublicKey.Substring(lBeginStart, (pPublicKey.Length - lBeginStart - lEndLenght));
            lDer = Convert.FromBase64String(KeyString);
            //Create a new instance of the RSAParameters structure.
            RSAParameters lRSAKeyInfo = new RSAParameters();
            lRSAKeyInfo.Modulus = GetModulus(lDer);
            lRSAKeyInfo.Exponent = GetExponent(lDer);
            return lRSAKeyInfo;
        }
        private static byte[] GetModulus(byte[] pDer)
        {
            //Size header is 29 bits
            //The key size modulus is 128 bits, but in hexa string the size is 2 digits => 256 
            string lModulus = BitConverter.ToString(pDer).Replace("-", "").Substring(58, 256);
            return StringHexToByteArray(lModulus);
        }
        private static byte[] GetExponent(byte[] pDer)
        {
            int lExponentLenght = pDer[pDer.Length - 3];
            string lExponent = BitConverter.ToString(pDer).Replace("-", "").Substring((pDer.Length * 2) - lExponentLenght * 2, lExponentLenght * 2);
            return StringHexToByteArray(lExponent);
        }    
        
        public static byte[] StringHexToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
