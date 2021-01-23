    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class ApiVersionRangeAttribute : Attribute
    {
        public int MinVersion { get; private set; }
        public int MaxVersion { get; private set; }
        public ApiVersionRangeAttribute(int minVersion, int maxVersion)
        {
            MinVersion = minVersion;
            MaxVersion = maxVersion;
        }
        public void Validate(int version)
        {
            if (version < MinVersion || version > MaxVersion)
            {
                throw new Exception("Upgrade");
            }
        }
    }
