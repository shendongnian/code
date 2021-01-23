    public string RemoveStopWords(string originalDoc){
        string updatedDoc = "";
        string[] originalDocSeperated = originalDoc.Split(' ');
        foreach (string word in originalDocSeperated)
        {
            if (!stopWordsDic.Contains(word))
            {
                string.Format("{0}{1}", word, string.Empty);
                //updatedDoc += word;
                //updatedDoc += " ";
            }
        }
        return updatedDoc.Substring(0, updatedDoc.Length - 1); //Remove Last Space
    }
