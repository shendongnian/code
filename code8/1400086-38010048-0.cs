    public static bool NewestUpdate(string Directoria, Version queryVersion)
    {
        Version version = null;
        return (from d in new DirectoryInfo(Directoria).EnumerateDirectories()
                where d.Name.ToLower().StartsWith("update_")
                let token = d.Name.Split('_')
                let vers = token.Length == 3 && Version.TryParse(token[2], out version) ? version : null
                where vers == queryVersion
                select d).Any();
    }
