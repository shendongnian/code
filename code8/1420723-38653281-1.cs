    public List<string> GetTags(string filePath)
    {
        string fileContents;
        // read the file if it exists
        if (File.Exists(filePath))
            fileContents = File.ReadAllText(filePath);
        else
            return null;
        // Find the place where "</Tags>" is located
        int tagEnd = fileContents.IndexOf("</Tags>");
            
        // Get the tags
        string tagString = fileContents.Substring(6, tagEnd - 6).Replace(Environment.NewLine, ""); // 6 comes from the length of "<Tags>"
        return tagString.Split(',').ToList();
    }
