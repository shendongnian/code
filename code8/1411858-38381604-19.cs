        private static void Serialize(Object objectToSerialize, FileStream stream)
        {
            try
            {
                DataContractSerializer serializer =
                       new DataContractSerializer(objectToSerialize.GetType());
                serializer.WriteObject(stream, objectToSerialize);
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to Deserialize");
                Debug.WriteLine(ex.Message);
            }
            return returnValue;
        }
