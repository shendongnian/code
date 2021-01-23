    string text;
    using (var file = new StreamReader(@"C:\FOLDER\FILE.txt")) 
    {
        text = file.ReadToEnd();
        if (text.Contains("server") )
        {
            foreach (Match match in Regex.Matches(text, @"(?s)server(.*?)Finished"))
                Console.WriteLine(match.Groups[1].Value);
            Console.ReadKey();
        }
    }
