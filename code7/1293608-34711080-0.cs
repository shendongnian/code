    using System;
    using System.Text;
    
    public class Test
    {
        public static void Main()
        {
            // our corrupted string
            string str = "ÑÁ"
            // encoding from step (2)
            Encoding enc1 = Encoding.GetEncoding(1252);
            byte[] bytes = enc1.GetBytes(str);
            // encoding from step (1)
            Encoding enc2 = Encoding.GetEncoding(1251);
            string originalStr = enc.GetString(bytes);
            Console.WriteLine(originalStr);
        }
    }
