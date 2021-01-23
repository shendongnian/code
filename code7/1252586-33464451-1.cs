    public static class SettingManager
    {
        public static void Save(string path, object obj)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            using (var s = new StreamWriter(path))
            {
                var xmlSerializer = new XmlSerializer(obj.GetType());
                xmlSerializer.Serialize(s, obj);
            }
        }
        public static T Load<T>(string path) where T : class, new()
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (File.Exists(path))
            {
                using (var s = new StreamReader(path))
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    return xmlSerializer.Deserialize(s) as T;
                }
            }
            return new T();
        }
    }
