    public class SettingSerializer
    {
        private string path;
        private string EXE = Assembly.GetExecutingAssembly().GetName().Name;
    
        public SettingSerializer(string xmlPath = null)
        {
            path = new FileInfo(xmlPath ?? EXE + ".xml").FullName.ToString();
        }
    
        public Settings Deserialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
    
            StreamReader reader = new StreamReader(path);
            var settings = (Settings)serializer.Deserialize(reader);
            reader.Close();
    
            return settings;
        }
    }
