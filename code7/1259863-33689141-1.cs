    public string RemoveStopWords(string originalDoc){
        string updatedDoc = "";
        string[] originalDocSeperated = originalDoc.Split(' ');
        foreach (string word in originalDocSeperated)
        {
            if (!stopWordsDic.Contains(word))
            {
                updatedDoc += word;
                updatedDoc += " ";
            }
        }
        return updatedDoc.Substring(0, updatedDoc.Length - 1); //Remove Last Space
    }
