    static void Main(string[] args)
    {
        string fileName = "C:\\Users\\Eric\\person.txt";
        using (StreamReader sr = File.OpenText(fileName))
        {
            string s = String.Empty;
            while ((s = sr.ReadLine()) != null)
            {
                Console.Write(s);
                Console.Write("\t");
            }
        }
    }
