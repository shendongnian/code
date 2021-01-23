    class Program
    {
        static void Main(string[] args)
        {
    
            string text = "/green/blah/agriculture/apple/blah/hallo/apple/green/blah/agriculture/apple/blah/hallo/apple";
            int idx = text.IndexOf("apple");
            if (idx < text.Length)
            {
                string first = text.Substring(0, idx);
                string second = text.Substring(idx + 5, text.Length - idx - 5);
                string result = first + "Orange" + second;
                Console.WriteLine(result);
            }
        }
    }
