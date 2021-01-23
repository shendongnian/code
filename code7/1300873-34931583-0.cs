        public void Save<T>(this T obj, string path)
        {
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            serializer.WriteObject(stream, obj);
        }
