    public string formatText(string longSentenceParts,int columnLimit)
    {
            string[] words = longSentence.Split(new char[] { ' ' });
            IList<string> longSentenceParts = new List<string>();
            longSentenceParts.Add(string.Empty);
            int partCounter = 0;
            foreach (string word in words)
            {
                if ((longSentenceParts[partCounter] + word).Length > columnLimit)
                {
                    partCounter++;
                    longSentenceParts.Add(string.Empty);
                }
                longSentenceParts[partCounter] += word + " ";
            }
            foreach (string x in longSentenceParts)
                Console.WriteLine(x);
    }
