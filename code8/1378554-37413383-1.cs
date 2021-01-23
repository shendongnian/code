    public class ConnectionStringUtility
    {
        public string Endpoint { get; private set; }
        public string SasKeyName { get; private set; }
        public string SasKeyValue { get; private set; }
        public ConnectionStringUtility(string connectionString)
        {
            //Parse Connectionstring
            char[] separator = { ';' };
            string[] parts = connectionString.Split(separator);
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].StartsWith("Endpoint"))
                    Endpoint = "https" + parts[i].Substring(11);
                if (parts[i].StartsWith("SharedAccessKeyName"))
                    SasKeyName = parts[i].Substring(20);
                if (parts[i].StartsWith("SharedAccessKey"))
                    SasKeyValue = parts[i].Substring(16);
            }
        }
        public string getSaSToken(string uri, int minUntilExpire)
        {
            string targetUri = Uri.EscapeDataString(uri.ToLower()).ToLower();
            // Add an expiration in seconds to it.
            long expiresOnDate = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            expiresOnDate += minUntilExpire * 60 * 1000;
            long expires_seconds = expiresOnDate / 1000;
            String toSign = targetUri + "\n" + expires_seconds;
            // Generate a HMAC-SHA256 hash or the uri and expiration using your secret key.
            MacAlgorithmProvider macAlgorithmProvider = MacAlgorithmProvider.OpenAlgorithm(MacAlgorithmNames.HmacSha256);
            BinaryStringEncoding encoding = BinaryStringEncoding.Utf8;
            var messageBuffer = CryptographicBuffer.ConvertStringToBinary(toSign, encoding);
            IBuffer keyBuffer = CryptographicBuffer.ConvertStringToBinary(SasKeyValue, encoding);
            CryptographicKey hmacKey = macAlgorithmProvider.CreateKey(keyBuffer);
            IBuffer signedMessage = CryptographicEngine.Sign(hmacKey, messageBuffer);
            string signature = Uri.EscapeDataString(CryptographicBuffer.EncodeToBase64String(signedMessage));
            return "SharedAccessSignature sr=" + targetUri + "&sig=" + signature + "&se=" + expires_seconds + "&skn=" + SasKeyName;
        }
    }
