    foreach (string sentence in allSentencesList) //for each string in the list do as following:
    {
        foreach (XmlNode entity in entityList) //Replace each word in the string:
        {
            string processedString = sentence.Replace((entity["text"].InnerText), 
                (entity["text"].InnerText + "/" + entity["type"].InnerText)); //replacing the words found in the 'text' tag with the aforementioned new word 
            processedSentencesList.Add(processedString); //adding the new sentence to the new list
        }
    }
