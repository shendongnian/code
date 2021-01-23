    public class ObjectPlus
    {
        // Replace with whatever file name is appropriate.  My computer doesn't have a "c:\tmp" directory.
        static string JsonFileName { get { return Path.Combine(Path.GetTempPath(), "dictionary.json"); } }
        static JsonSerializerSettings JsonSettings { get { return new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented }; } }
        private static Dictionary<Type, List<Object>> _ekstensje = new Dictionary<Type, List<Object>>();
        public static void SerializeDictionary()
        {
            var path = JsonFileName;
            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read))
            using (var writer = new StreamWriter(stream))
            {
                var serializer = JsonSerializer.CreateDefault(JsonSettings);
                serializer.Serialize(writer, _ekstensje);
            }
        }
        public static void DeserializeDictionary()
        {
            var path = JsonFileName;
            try
            {
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (var reader = new StreamReader(stream))
                using (var jsonReader = new JsonTextReader(reader))
                {
                    var serializer = JsonSerializer.CreateDefault(JsonSettings);
                    _ekstensje = serializer.Deserialize<Dictionary<Type, List<Object>>>(jsonReader);
                }
            }
            catch (FileNotFoundException)
            {
                // File was not created yet, dictionary should be empty.
                _ekstensje.Clear();
            }
        }
        public static List<Object> GetEkstensja(Type className)
        {
            List<Object> list = _ekstensje[className];
            return list;
        }
        public static void AddEkstensja<T>(T obj)
        {
            List<Object> list;
            if (!_ekstensje.TryGetValue(obj.GetType(), out list))
                list = _ekstensje[obj.GetType()] = new List<object>();
            list.Add(obj);
        }
        internal static string ShowJsonContents()
        {
            if (!File.Exists(JsonFileName))
                return string.Empty;
            return File.ReadAllText(JsonFileName);
        }
    }
