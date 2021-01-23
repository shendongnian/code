    var regex = new Regex(@"^V(\d+)_(\d+)_(\d+)$", RegexOptions.Compiled);
    var versions = directoryList 
        .Select(f => regex.Match(f))
        .Where(m => m.Success)
        .Select(m => new
        {
            Major = Int32.Parse(m.Groups[1].Value),
            Minor = Int32.Parse(m.Groups[2].Value),
            Patch = Int32.Parse(m.Groups[3].Value)
        }).ToList();
        var major = versions.Max(a => a.Major);
        versions = versions
            .Where(a => a.Major == major)
            .ToList();
        var minor = versions.Max(a => a.Minor);
        versions = versions
            .Where(a => a.Minor == minor)
            .ToList();
        var patch = versions.Max(a => a.Patch);
        versions = versions
            .Where(a => a.Patch == patch)
            .ToList();
        var newest = versions.First();
        var filename = String.Format("V_{0}_{1}_{2}", newest.Major, newest.Minor, newest.Patch);
