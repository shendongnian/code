    public static class proSave
    {
        private static propertyClass settings;
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
        private static propertyClass GetSettings()
        {
            XmlSerializer serialize = new XmlSerializer(typeof(propertyClass));
            var stream = new StreamReader("C:\\settings.xml");
            return (propertyClass)serialize.Deserialize(stream);
        }
    }
