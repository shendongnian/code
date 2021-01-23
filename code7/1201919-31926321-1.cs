    public static List<Version> GetLibraryVersions(List<string> files, string Name)
    {
        string regexPattern = String.Format(@"\A{0}(?:.*?)(?:\.)(\d+(?:\.\d+){{2,3}})(?:\.)(?:.*)\Z", Regex.Escape(Name));
        Regex regex = new Regex(regexPattern);
        return files.Where(f => regex.Match(f).Success).
                Select(f => new Version(regex.Match(f).Groups[1].Value)).ToList();
    }
