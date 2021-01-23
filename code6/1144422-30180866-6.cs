    /// <summary>Generic class to support serializing lists/collections to a settings file.</summary>
    [Serializable()]
    public class SettingsList<T> : System.Collections.ObjectModel.Collection<T> 
    {
        public string ToBase64()
        {
            // If you don't want a crash& burn at runtime should probaby add 
            // this guard clause in: 'if (typeof(T).IsDefined(typeof(SerializableAttribute), false))'
                using (var stream = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    stream.Position = 0;
                    byte[] buffer = new byte[(int)stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    return Convert.ToBase64String(buffer);
                }
        }
        public static SettingsList<T> FromBase64(string settingsList)
        {
            using (var stream = new MemoryStream(Convert.FromBase64String(settingsList)))
            {
                var deserialized = new BinaryFormatter().Deserialize(stream);
                return (SettingsList<T>)deserialized;
            }
        }  
    }
    [Serializable()]
    public class SettingsObject
    {
        public string Property { get; set; }
        public SettingsObject()
        {
        }
    }
    
