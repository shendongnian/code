    [Serializable]
    sealed class Settings
    {
        internal Dictionary<string, Color> ForeColors { get; set; }
        internal Dictionary<string, Color> BackColors { get; set; }
        internal Settings()
    	{
            ForeColors = new Dictionary<string, Color>();
            BackColors = new Dictionary<string, Color>();
	    }
        internal void Save(string fileName = @"settings.ini")
        {
            using (FileStream stream = File.Create(Directory.GetCurrentDirectory() + "\\" + fileName))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(stream, this);
            }
        }
        internal static Settings Load(string fileName = @"settings.ini")
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\" + fileName)) return null;
            using (FileStream stream = File.OpenRead(Directory.GetCurrentDirectory() + "\\" + fileName))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                return serializer.Deserialize(stream) as Settings;
            }
        }
    }
