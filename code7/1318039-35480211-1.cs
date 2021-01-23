     class Program
    {
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        static void Main(string[] args)
        {
            //Client client = new Client();
            string code = "SecretCode";
            byte[] data = new byte[code.Length];
            byte[] result;
            data = GetBytes(code);
            SHA384 shaM = new SHA384Managed();
            result = shaM.ComputeHash(data);
            string encodedString = GetString(result);
            string ans = Base64Encode(encodedString);
            ans = ans.Replace('+','-').Replace('/','_');
            Console.Write(ans);
            Console.Read();
        }
    }
