    var processedSentencesList = new List<string>();
    foreach (XmlNode entity in entityList) //xmlnode list containing two xml tags: text and type 
    {
        foreach (string sentence in allSentencesList) //list containing sentences
        {
            string processedString = sentence.Replace((entity["text"].InnerText), 
                (entity["text"].InnerText + "/" + entity["type"].InnerText)); //replacing the words found in the 'text' tag with the aforementioned new word 
            processedSentencesList.Add(processedString); //adding the new sentence to the new list
        }
    }
