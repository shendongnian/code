    /// <summary>
    /// Represents the chargify web hook class.
    /// </summary>
    public class ChargifyWebHook
    {
        /// <summary>
        /// Indicates whether the raw data has already been parsed or not.
        /// </summary>
        private bool initialized;
        /// <summary>
        /// Contains the key value pairs extracted from the raw data.
        /// </summary>
        private Dictionary<string, string> keyValuePairs;
        /// <summary>
        /// Initializes a new instance of the <see cref="ChargifyWebHook"/> class.
        /// </summary>
        /// <param name="data">The raw data of the web hook.</param>
        /// <exception cref="System.ArgumentException">Is thrown if the sepcified raw data is null or empty.</exception>
        public ChargifyWebHook(string data)
        {
            if (String.IsNullOrEmpty(data))
            {
                throw new ArgumentException("The specified value must neither be null nor empty", data);
            }
            this.initialized = false;
            this.keyValuePairs = new Dictionary<string, string>();
            this.RawData = data;
        }
        /// <summary>
        /// Gets the raw data of the web hook.
        /// </summary>
        public string RawData
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets the key value pairs contained in the raw data.
        /// </summary>
        public Dictionary<string, string> KeyValuePairs
        {
            get
            {
                if (!initialized)
                {
                    this.keyValuePairs = ExtractKeyValuesFromRawData(this.RawData);
                    initialized = true;
                }
                return this.keyValuePairs;
            }
        }
        /// <summary>
        /// Extracts the key value pairs from the specified raw data.
        /// </summary>
        /// <param name="rawData">The data which contains the key value pairs.</param>
        /// <param name="keyValuePairSeperator">The pair seperator, default is '&'.</param>
        /// <param name="keyValueSeperator">The key value seperator, default is '='.</param>
        /// <returns>The extracted key value pairs.</returns>
        /// <exception cref="System.FormatException">Is thrown if an key value seperator is missing.</exception>
        public static Dictionary<string, string> ExtractKeyValuesFromRawData(string rawData, char keyValuePairSeperator = '&', char keyValueSeperator = '=')
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            string[] rawDataParts = rawData.Split(new char[] { keyValuePairSeperator });
            foreach (string rawDataPart in rawDataParts)
            {
                string[] keyAndValue = rawDataPart.Split(new char[] { keyValueSeperator });
                if (keyAndValue.Length != 2)
                {
                    throw new FormatException("The format of the specified raw data is incorrect. Key value pairs in the following format expected: key=value or key1=value1&key2=value2...");
                }
                keyValuePairs.Add(keyAndValue[0], keyAndValue[1]);
            }
            return keyValuePairs;
        }
        /// <summary>
        /// Extracts the hierarchy from the key, e.g. A[B][C] will result in A, B and C.
        /// </summary>
        /// <param name="key">The key who's hierarchy shall be extracted.</param>
        /// <param name="hierarchyOpenSequence">Specifies the open sequence for the hierarchy speration.</param>
        /// <param name="hierarchyCloseSequence">Specifies the close sequence for the hierarchy speration.</param>
        /// <returns>A list of entries for the hierarchy names.</returns>
        public static List<string> ExtractHierarchyFromKey(string key, string hierarchyOpenSequence = "[", string hierarchyCloseSequence = "]")
        {
            if (key.Contains(hierarchyOpenSequence) && key.Contains(hierarchyCloseSequence))
            {
                return key.Replace(hierarchyCloseSequence, string.Empty).Split(new string[] { hierarchyOpenSequence }, StringSplitOptions.None).ToList();
            }
            if (key.Contains(hierarchyOpenSequence) && !key.Contains(hierarchyCloseSequence))
            {
                return key.Split(new string[] { hierarchyOpenSequence }, StringSplitOptions.None).ToList();
            }
            if (!key.Contains(hierarchyOpenSequence) && key.Contains(hierarchyCloseSequence))
            {
                return key.Split(new string[] { hierarchyCloseSequence }, StringSplitOptions.None).ToList();
            }
            return new List<string>() { key };
        }
    }
