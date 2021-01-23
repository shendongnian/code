    string json = @"{""A"":[""a"",""b"",""c"",""d""],""B"":[""a""],""C"":[]}";
    JavaScriptSerializer serializer = new JavaScriptSerializer();
    Dictionary<string, List<string>> myObject = 
        serializer.Deserialize<Dictionary<string, List<string>>>(json);
    foreach (KeyValuePair<string, List<string>> kvp in myObject)
    {
        Console.WriteLine(kvp.Key + ": " + string.Join(",", kvp.Value));
    }
