    // If this class is immutable, consider marking it with:
    // [Pure]
    public class SemanticVersion
    {
        private readonly int _majorVersion;
        private readonly int _minorVersion;
        private readonly int _patchVersion;
        private readonly Maybe<T> _buildVersion;
        private readonly Maybe<T> _prereleaseVersion;
        public SemanticVersion(string version)
        {
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(version));
            var match = SemanticVersionRegex.Match(version);
            if (!match.Success)
            {
                var message = $"The version number '{version}' is not a valid semantic version number.";
                throw new ArgumentException(message, nameof(version));
            }
            _majorVersion = int.Parse(match.Groups["major"].Value, CultureInfo.InvariantCulture);
            _minorVersion = int.Parse(match.Groups["minor"].Value, CultureInfo.InvariantCulture);
            _patchVersion = int.Parse(match.Groups["patch"].Value, CultureInfo.InvariantCulture);
            _prereleaseVersion = match.Groups["prerelease"].Success
                ? new Maybe<string>(match.Groups["prerelease"].Value)
                : Maybe<string>.Empty;
            _buildVersion = match.Groups["build"].Success
                ? new Maybe<string>(match.Groups["build"].Value)
                : Maybe<string>.Empty;
        }
        [ContractInvariantMethod]
        private void ObjectInvariants()
        {
            Contract.Invariant(_majorVersion >= 0);
            Contract.Invariant(_minorVersion >= 0);
            Contract.Invariant(_patchVersion >= 0);
            Contract.Invariant(_prereleaseVersion != null);
            Contract.Invariant(_buildVersion != null);
        }
        // Properties that only contain getters are automatically
        // considered Pure by Code Contracts. But also, this point
        // is moot if you make the entire class Pure if it's
        // immutable.
        public int MajorVersion => _majorVersion;
        public int MinorVersion => _minorVersion;
        public int PatchVersion => _patchVersion;
        public Maybe<T> PrereleaseVersion => _prereleaseVersion;
        public Maybe<T> BuildVersion => _buildVersion;
    }
