    [ConfigurationProperty("dataCenterRegion", DefaultValue = null)]
    public string DataCenterRegion
    {
        get { return ((string)this["dataCenterRegion"]).ToNullIfEmpty(); }
        set { this["dataCenterRegion"] = value; }
    }
    public static partial class ExtensionMethods
    {        
        /// <summary>
        /// Return null if the string is empty or is already null.
        /// Otherwise, return the original string.
        /// </summary>
        public static string ToNullIfEmpty(this string str)
        {
            return String.IsNullOrEmpty(str) ? null : str;
        }
        /// <summary>
        /// Return null if the string is white space, empty or is already null.
        /// Otherwise, return the original string.
        /// </summary>
        public static string ToNullIfWhiteSpaceOrEmpty(this string str)
        {
            return String.IsNullOrWhiteSpace(str) ? null : str;
        }
    }
