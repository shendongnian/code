    public class ElectrodeManager
    {
        #region Singleton Pattern
        private static ElectrodeManager instance;
        public static ElectrodeManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ElectrodeManager();
                return instance;
            }
        }
        private ElectrodeManager()
        {
            electrodes = new Dictionary<string, string>();
        }
        #endregion
        #region Fields
        private Dictionary<string, string> electrodes;
        #endregion Fields
        #region Methods
        public void AddElectrode(string eType, string eKey)
        {
            if (!electrodes.ContainsKey(eType))
            {
                electrodes.Add(eType, eKey);
            }
        }
        public void AppendStringToElectrodeKey(string eType, string keyAddendum)
        {
            string electrodeKey = String.Empty;
            if (electrodes.TryGetValue(eType, out electrodeKey))
            {
                electrodes[eType] = String.Format("{0}-{1}", electrodes[eType], keyAddendum);
            }
        }
        public IDictionary<string, string> GetElectrodes()
        {
            return electrodes;
        }
        #endregion Methods
    }
