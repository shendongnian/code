    string input = "4.0.9";
    var version = Version.Parse(input);
    var output = versions.SkipWhile(a => a.Version < version);
    var first = output.FirstOrDefault();
    if (first != null && !first.FutureReleases)
    {
        output = versions.TakeWhile(a => a.Version == version);
    }
