        string lines;
        try
        {   // Open the text file using a stream reader.
            using (StreamReader sr = new StreamReader("TestFile.txt"))
               lines = sr.ReadToEnd();     
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        List<string> sentences = Regex.Split("", @"(?<=[\.!\?])\s+").ToList();
        var longestSentences = sentences.Where(s => s.Length == sentences.Max(l => l.Length));
        List<int> indexsOfLongestSentences = new List<int>();
            
        if(longestSentences.Any())
                indexsOfLongestSentences.AddRange(longestSentences.Select(longestSentence => sentences.IndexOf(longestSentence)));
