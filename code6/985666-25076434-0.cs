        private void Form1_Load(object sender, EventArgs e)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ApplicationSettings));
                    XmlReader reader = XmlReader.Create(new StringReader(
                        @"<?xml version=""1.0""?> <ApplicationSettings>
     <SelectedGeneralSetting>Default</SelectedGeneralSetting>
        <GeneralSettings>
        <GeneralSetting><Name>DDD</Name></GeneralSetting>
        </GeneralSettings></ApplicationSettings>"));
                    var result = (serializer.Deserialize(reader) as ApplicationSettings);
                }
        
                [Serializable]
                public class ApplicationSettings
                {
                    public string SelectedGeneralSetting { get; set; }
                    public List<GeneralSetting> GeneralSettings = new List<GeneralSetting>();
                }
        
                public class GeneralSetting
                {
                    public string Name { get; set; }
                }
