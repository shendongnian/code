    string readContents;
    using (StreamReader streamReader = new StreamReader(@"File.txt"))
    {
        readContents = streamReader.ReadToEnd();
        string[] lines = readContents.Split('\r');
        foreach (string s in lines)
        {
             string[] lines2 = s.Split('\t');
             foreach (string s2 in lines2)
             {
                 Console.WriteLine(s2);
             }
        }
    }
    Console.ReadLine();
