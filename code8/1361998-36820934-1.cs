    using System.Xml.Linq;
    public static class SettingsProvider
    {
        private const string settingsFileName = "settings.xml";
        private static readonly XDocument settings = XDocument.Load(settingsFileName);
        public static string GetValue(string section, string key, string defaultValue)
        {
            XElement settingElement = GetSettingElement(section, key);
            return settingElement == null ? defaultValue : settingElement.Value;
        }
        public static void SetValue(string section, string key, string value)
        {
            XElement settingElement = GetSettingElement(section, key, true);
            settingElement.Value = value;
            settings.Save(settingsFileName);
        }
        private static XElement GetSettingElement(string section, string key, bool createIfNotExist = false)
        {
            XElement sectionElement =
                settings
                    .Root
                    .Elements(section)
                    .FirstOrDefault();
            if (sectionElement == null)
            {
                if (createIfNotExist)
                {
                    sectionElement = new XElement(section);
                    settings.Root.Add(sectionElement);
                }
                else
                {
                    return null;
                }
            }
            XElement settingElement =
                sectionElement
                    .Elements(key)
                    .FirstOrDefault();
            if (settingElement == null)
            {
                if (createIfNotExist)
                {
                    settingElement = new XElement(key);
                    sectionElement.Add(settingElement);
                }
            }
            return settingElement;
        }
        public static void RemoveSetting(string section, string key)
        {
            XElement settingElement = GetSettingElement(section, key);
            if (settingElement == null)
            {
                return;
            }
            XElement sectionElement = settingElement.Parent;
            settingElement.Remove();
            if (sectionElement.IsEmpty)
            {
                sectionElement.Remove();
            }
            settings.Save(settingsFileName);
        }
    }
