        public static T DeserializeJson<T>(string objectInJson)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(JsonSerializer.StringToStream(objectInJson));
        }
