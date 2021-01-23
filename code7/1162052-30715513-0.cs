    string Serialize(List<string> list)
    {
        StringBuilder result = new StringBuilder();
        foreach (string s in list)
        {
            result.AppendFormat("{0}{1}", result.Length > 0 ? "," : "", s);
        }
        return result.ToString();
    }
    List<string> Deserialize(string s)
    {
        return new List<string>(s.Split(','));
    }
