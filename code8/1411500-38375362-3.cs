    public static class Save 
    {
        public static void SaveData<T>(string key, object value) where T : class
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, value as T);
            PlayerPrefs.SetString(key, Convert.ToBase64String(ms.GetBuffer()));
        }
     
        public static T GetDataArray<T>(string key) where T: class
        {
            if (PlayerPrefs.HasKey(key) == false) { return null; }
            string str = PlayerPrefs.GetString(key);
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(Convert.FromBase64String(str));
            return bf.Deserialize(ms) as T;
        }
    }
