           public static string SerializeJSon<T>(T objectData)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(T));
                ds.WriteObject(stream, objectData);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
