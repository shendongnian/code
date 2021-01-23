    List<string> lines = new List<string>();
    using (StreamReader reader = new StreamReader("Assets/test.txt"))
    {
        string lines = reader.ReadToEnd();
        Debug.Log(lines);
        var splitText = lines.Split(new string[] { "|" },
            System.StringSplitOptions.RemoveEmptyEntries);
        string result = String.Empty;
        foreach (var dataEntry in splitText)
        {
            string dataToParse = dataEntry.Trim();
            result += dataToParse + Environment.NewLine;
        }
        Debug.Log(result);
    }
