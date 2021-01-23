    public static class MySerializer
    {
        public static T ToObject<T>(string path, string fileName)
            {
                string fullPath = path + fileName;
                if (!path.EndsWith("/"))
                {
                    fullPath = path + "/" + fileName;
                }
    
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StreamReader fileReader = new StreamReader(fullPath))
                {
                    T instance = (T)serializer.Deserialize(fileReader);
    
                    return instance;
                } 
            }
    
            public static void ToFile<T>(T currentObject, string path, string fileName)
            {
                string fullPath = path + fileName;
                if (!path.EndsWith("/"))
                {
                    fullPath = path + "/" + fileName;
                }
    
                XmlSerializer serializer = new XmlSerializer(typeof(T));
    
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(fullPath))
                {
                    serializer.Serialize(file, currentObject);
                }
            }
    
    }
