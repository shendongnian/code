    public static class proSave
    {
        private static propertyClass settings;
        private const string SettingsFilePath = "C:\\settings.xml";
        public static propertyClass oku
        {
            get
            {
                if (settings == null)
                {
                    settings = GetSettings();
                    return settings;
                }
                return settings;
            }
        }
        public static void SaveSettings(propertyClass settings)
        {
            XmlSerializer writer = new XmlSerializer(typeof(propertyClass));
            using (FileStream file = File.Create(SettingsFilePath))
            {
                writer.Serialize(file, settings);
            }
        }
        private static propertyClass GetSettings()
        {
            XmlSerializer serialize = new XmlSerializer(typeof(propertyClass));
            using (var stream = new StreamReader(SettingsFilePath))
            {
                return (propertyClass)serialize.Deserialize(stream);
            }
        }
    }
