    public class SettingsXmlSerializer : XmlSerializer {
        protected override object Deserialize(XmlSerializationReader reader) {
            var settings = (Settings)base.Deserialize(reader);
            settings.InnerSettings.RemoveAt(0);
            return settings;
        }
    }
