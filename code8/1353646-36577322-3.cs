    Version version = null;
    Version lastVersion = new DirectoryInfo(Directoria).EnumerateDirectories()
        .Where(d => d.Name.StartsWith("UPDATE_"))
        .Select(d => new {Directory = d, Token = d.Name.Split('_')})
        .Where(x => x.Token.Length == 3 && Version.TryParse(x.Token[2], out version))
        .Select(x => new {x.Directory, Date = x.Token[1], Version = version})
        .OrderByDescending(x => x.Version)
        .Select(x => x.Version)
        .FirstOrDefault();
    string latestVersion = lastVersion.ToString(); // if you want it as string
 
