    public static class DynamicResourceManager
    {
        private static readonly Dictionary<string, string> dictionary;
        // are there any changes
        private static bool isDirty = false;
        // The current language of the resources to manage
        private static CultureInfo activeLanguage = CultureInfo.CurrentUICulture;
        public static CultureInfo ActiveLanguage
        {
            get { return activeLanguage; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                if (!activeLanguage.Equals(value))
                {
                    if (isDirty)
                        SaveDictionary();
                    activeLanguage = value;
                    LoadDictionary();
                }
            }
        }
        private static void LoadDictionary()
        {
            // The ResourceManager is case-insensitive so we are, too
            if (dictionary == null)
                 dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            else
                dictionary.Clear();
            string file = GetFileName();
            if (!File.Exists(file))
                return;
            using (IResourceReader reader = new ResXResourceReader(file))
            {
                foreach (DictionaryEntry item in reader)
                {
                    string value = item.Value as string;
                    if (value != null)
                        dictionary.Add(item.Key.ToString(), value);
                }
            }
        }
        // this should be called explicitly when you exit the application, but
        // is called automatically when ActiveLanguage is changed
        public static void SaveDictionary()
        {
            if (!isDirty)
                return;
            string file = GetFileName();
            string dir = Path.GetDirectoryName(file);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            using (IResourceWriter writer = new ResXResourceWriter(file))
            {
                foreach (KeyValuePair<string, string> item in dictionary)
                    writer.AddResource(item.Key, item.Value);
            }
            isDirty = false;            
        }
        private static string GetFileName()
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Languages") + activeLanguage.Name + ".resx");
        }
        public static string GetString(string key)
        {
            if (key == null)
                return String.Empty;
            if (dictionary == null)
                LoadDictionary();
            string result;
            if (!dictionary.TryGetValue(key, out result))
            {
                // entry not found in this language, adding it dynamically
                dictionary.Add("NEW:" + key, key);
                isDirty = true;
            }
            return result;
        }
        public static void SetString(string key)
        {
            if (dictionary == null)
                LoadDictionary();
            dictionary[key] = value;
            isDirty = true;
        }
    }
