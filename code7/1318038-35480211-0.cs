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
        static void Main(string[] args)
        {
            //Client client = new Client();
            string code = "SecretCode";
            byte[] data = new byte[code.Length];
            byte[] result;
            SHA384 shaM = new SHA384Managed();
            result = shaM.ComputeHash(data);
            string ans = Base64Encode(result.ToString());
            ans = ans.Replace('+','-').Replace('/','_');
            Console.Write(ans);
            Console.Read();
        }
    }
