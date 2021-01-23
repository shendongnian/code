        public static void SaveObject(SerializeableObject value)
        {
            Serialize(value, new FileStream(ApplicationData.Current.RoamingFolder.Path 
                + @"\" + value.objectName + ".russ", FileMode.OpenOrCreate));
        }
        public static Object GetObject(string objectName, Type targetType)
        {
            return Deserialize(new FileStream(ApplicationData.Current.RoamingFolder.Path
               + @"\" + objectName + ".russ", FileMode.OpenOrCreate), targetType);
        }
        private static void Serialize(SerializeableObject objectToSerialize, FileStream stream)
        {
            try
            {
                DataContractSerializer serializer = objectToSerialize.GetSerializer();
                serializer.WriteObject(stream, objectToSerialize);
                stream.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to Serialize");
                Debug.WriteLine(ex.Message);
            }
        }
        private static Object Deserialize(FileStream stream, Type targetType)
        {
            Object returnValue = null;
            try
            {
                DataContractSerializer serializer =
                      new DataContractSerializer(targetType);
                stream.Position = 0;
                returnValue = serializer.ReadObject(stream);
                stream.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to Deserialize");
                Debug.WriteLine(ex.Message);
            }
            return returnValue;
        }
