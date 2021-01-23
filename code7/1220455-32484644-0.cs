    public IEnumerable<string> GetSubPaths(string s)
    {
        var sb = new StringBuilder();
        for(int i = 0; i < s.Length; s++)
        {
            if(s[i] == '\\')
                yield return sb.ToString();
            sb.Append(s[i]);
        }
        yield return sb.ToString();
    }
