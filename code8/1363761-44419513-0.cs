    private static void CreateToken(string message, string key)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[]keyByte = encoding.GetBytes(key);
        
            
            HMACSHA256 hmacsha = new HMACSHA256(keyByte);
            byte[]messageBytes = encoding.GetBytes(message);
            
            byte[]hashmessage = hmacsha.ComputeHash(messageBytes);
            Console.WriteLine(ByteToString(hashmessage));
        }
        public static string ByteToString(byte[]buff) {
            string sbinary = "";
        
            for (int i = 0; i < buff.Length; i++) {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary);
        }
