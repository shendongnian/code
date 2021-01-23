     public static void BinarySerializeObject(string path, object obj)
        {
          using (StreamWriter streamWriter = new StreamWriter(path))
          {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
              binaryFormatter.Serialize(streamWriter.BaseStream, obj);
            }
            catch (SerializationException ex)
            {
              throw new SerializationException(((object) ex).ToString() + "\n" + ex.Source);
            }
          }
        }
    
        public static object BinaryDeserializeObject(string path)
        {
          using (StreamReader streamReader = new StreamReader(path))
          {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            object obj;
            try
            {
              obj = binaryFormatter.Deserialize(streamReader.BaseStream);
            }
            catch (SerializationException ex)
            {
              throw new SerializationException(((object) ex).ToString() + "\n" + ex.Source);
            }
            return obj;
          }
        }
