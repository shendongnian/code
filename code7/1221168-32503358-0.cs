    using System.Configuration;
    public class MyConfig : ConfigurationSection
    {
        [ConfigurationProperty("Title", DefaultValue = "name", IsRequired = true)]
        public string Title
        {
            get { return (string)this["Title"]; }
            set { this["Title"] = value; }
        }
        [ConfigurationProperty("Code", DefaultValue = "123", IsRequired = true)]
        public string Code
        {
            get { return (string)this["Code"]; }
            set { this["Code"] = value; }
        }
        [ConfigurationProperty("Name", DefaultValue = " something", IsRequired = true)]
        public string Name
        {
            get { return (string)this["Name"]; }
            set { this["Name"] = value; }
        }
        private const string sectionName = "MyConfig";
        internal static MyConfig LoadConfig()
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            MyConfig section;
            if (cfg.Sections[sectionName] == null)
            {
                section = new MyConfig();
                cfg.Sections.Add(sectionName, section);
                section = cfg.GetSection(sectionName) as MyConfig;
                section.SectionInformation.ForceSave = true;
                cfg.Save(ConfigurationSaveMode.Full);
            }
            else
            {
                section = cfg.GetSection(sectionName) as MyConfig;
            }
            return section;
        }
    }
