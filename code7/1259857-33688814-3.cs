            Regex validWords = New Regex("^\s*([a-zA-Z0-9]+)");
            string stopWordsContent = System.IO.File.ReadAllText(stopWordsPath);
            string[] stopWordsSeperated = stopWordsContent.Split('\n');
            foreach (string stopWord in stopWordsSeperated)
            {
                stopWordsDic.Add(validWords.Match(stopWord).Value, 1);
            }
