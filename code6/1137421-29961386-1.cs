    static void Main(string[] args)
    {
        char[] delimiterChars = { ' ', ',', '.', ':', '?', '!' };
            Console.Write("Enter a sentence: ");
            string x = "Hello, my name is Ann!";
            Console.WriteLine("The sentence is: ", x);
            string[] words = x.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("{0} words in text:", words.Length);
            foreach (string s in words)
            {
                Console.WriteLine(s);
            }
        }
