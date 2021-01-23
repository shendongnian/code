    public Dictionary<string, object> GetHierarchy(Dictionary<string, object> root, string path, string value)
    {
        string[] parts = path.Split('.');
        if (parts.Length > 1)
        {
            if(!root.ContainsKey(parts[0]))
                root.Add(parts[0], new Dictionary<string, object>());
            Dictionary<string, object> dict = root[parts[0]] as Dictionary<string, object>;
            GetMe(dict, path.Replace(parts[0] + ".", string.Empty), value);
        }
        else 
            root[parts[0]] = value;
        return root;
    }
