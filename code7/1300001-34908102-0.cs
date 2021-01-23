    class Program
    {
        private const string encoded = "537465616d6c696e6564";
         
        static void Main(string[] args)
        {
            byte[] bytes = StringToByteArray(encoded);
            
            string text = Encoding.ASCII.GetString(bytes);
            
            Console.WriteLine(text);
            Console.ReadKey();
        }
        // From http://stackoverflow.com/questions/311165/how-do-you-convert-byte-array-to-hexadecimal-string-and-vice-versa
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
