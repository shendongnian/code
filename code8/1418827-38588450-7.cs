    Dictionary<string,string> Tags;
    string mask;
    string output = mask;
    foreach(var tag in tags)
    {
        output = output.Replace(tag.Key,tag.Value)
    }
