    public class KeyHandler: ConfigurationSection
    {
        #region Configuration Properties
        [ConfigurationProperty("KeyValueCollection")]
        public string KeyValueCollection
        {
            get { return this["KeyValueCollection"] as KeyValueCollection; }
        }
        #endregion
    }
