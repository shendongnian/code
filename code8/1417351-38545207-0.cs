    public class GlobalSettings
    {
        public double RedFiber { get; set; }
        public double GreenFiber { get; set; }
        public double BlueFiber { get; set; }
        public bool DeleteMinorViews { get; set; }
        
        public static GlobalSettings Load()
        {
            try
            {
                return JsonConvert.DeserializeObject<GlobalSettings>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\YOUR_APP_NAME\\"));
            }
            catch ()
            {
                return DefaultSettings;                
            }
            
        }
        public void Save()
        {
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\YOUR_APP_NAME\\", JsonConvert.SerializeObject(this, Formatting.Indented));
        }
        private static readonly GlobalSettings DefaultSettings = new GlobalSettings()
        {
			RedFiber = 0,
            GreenFiber = 255,
            BlueFiber = 0,
            DeleteMinorViews = true,
        };
    }
