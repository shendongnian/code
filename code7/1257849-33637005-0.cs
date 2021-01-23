    public SemanticVersion(string version)
    {
        Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(version));
        Contract.Ensures(MajorVersion >= 0);
        Contract.Ensures(MinorVersion >= 0);
        Contract.Ensures(PatchVersion >= 0);
        Contract.Ensures(PrereleaseVersion != null);
        Contract.Ensures(BuildVersion != null);
        var match = SemanticVersionRegex.Match(version);
        if (!match.Success)
        {
            // set the values here
            PrereleaseVersion = Maybe<string>.Empty;
            BuildVersion =  Maybe<string>.Empty;
            var message = $"The version number '{version}' is not a valid semantic version number.";
            throw new ArgumentException(message, nameof(version));
        }
        MajorVersion = int.Parse(match.Groups["major"].Value, CultureInfo.InvariantCulture);
        MinorVersion = int.Parse(match.Groups["minor"].Value, CultureInfo.InvariantCulture);
        PatchVersion = int.Parse(match.Groups["patch"].Value, CultureInfo.InvariantCulture);
        PrereleaseVersion = match.Groups["prerelease"].Success
            ? new Maybe<string>(match.Groups["prerelease"].Value)
            : Maybe<string>.Empty;
        BuildVersion = match.Groups["build"].Success
            ? new Maybe<string>(match.Groups["build"].Value)
            : Maybe<string>.Empty;
    }
