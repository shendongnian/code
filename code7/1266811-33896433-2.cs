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
        string[] sentences = Regex.Split(lines, @"(?<=[\.!\?])\s+");
        string longestSentence = sentences.Max(l=>l.Length);
        int sentenceNumber = sentences.IndexOf(longestSentence);
