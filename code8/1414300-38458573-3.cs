    public class BadExtensionData
    {
        Dictionary<string, object> extensionData;
        [JsonExtensionData]
        public Dictionary<string, object> ExtensionData { set { extensionData = value; } }
    }
