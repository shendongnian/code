    public static string DeleteSignature(string s)
    {
        if (s.Contains("[]{"))
        {
            var firstEntry = s.IndexOf("[]{");
            var closeEntry = s.IndexOf('}');
            s = s.Remove(firstEntry, closeEntry - firstEntry + 1);
            return DeleteSignature(s);
        }
        return s;
    }
