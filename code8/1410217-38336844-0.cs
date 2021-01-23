    string[] readText = File.ReadAllLines(@"p:\CARTAP1.txt");
    foreach (string s in readText)
    {
        if (s.Trim().StartsWith("D"))
        {
            Console.WriteLine(s);
        }
    }
