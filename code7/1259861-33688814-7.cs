            // Regex to find the first word inside a string regardless of the 
            // preleading symbols. Cuts away all nonword symbols afterwards
            Regex validWords = New Regex(@"\b([0-9a-zA-Z]+?)\b");
            string stopWordsContent = System.IO.File.ReadAllText(stopWordsPath);
            string[] stopWordsSeperated = stopWordsContent.Split('\n');
            foreach (string stopWord in stopWordsSeperated)
            {
                stopWordsDic.Add(validWords.Match(stopWord).Value, 1);
            }
