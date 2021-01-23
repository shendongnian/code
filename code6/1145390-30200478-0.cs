    string readContents;
    using (StreamReader streamReader = new StreamReader(@"File.txt"))
    {
        readContents = streamReader.ReadToEnd();
        string[] lines = readContents.Split('\r');
        List<string> pieces = new List<string>();
        foreach (string s in lines)
        {
            pieces.AddRange(s.Split('\t'));
            Console.WriteLine(s);
        }
    }
    Console.ReadLine();
