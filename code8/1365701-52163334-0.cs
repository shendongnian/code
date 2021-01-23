        private string GetHashedMessage(String _secret)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(_secret);
            String _message= "Your message that needs to be hashed";
            HMACSHA1 hmacsha1 = new HMACSHA1(keyByte);
        
            byte[] messageBytes = encoding.GetBytes(_message);
            byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
            return ByteToString(hashmessage).ToLower();
        }
        public string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary);
        }
