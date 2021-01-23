    var obj = jsonString.Deserialize<List<ListItem>>();
    public static T Deserialize<T>(this string json)
            {
                T returnValue;
                using (var memoryStream = new MemoryStream())
                {
                    var settings = new DataContractJsonSerializerSettings
                    {
                        DateTimeFormat = new System.Runtime.Serialization.DateTimeFormat("yyyy-MM-dd HH:mm:ssZ") 
                        
                    };
                    byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
                    memoryStream.Write(jsonBytes, 0, jsonBytes.Length);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    using (var jsonReader = JsonReaderWriterFactory.CreateJsonReader(memoryStream, Encoding.UTF8, XmlDictionaryReaderQuotas.Max, null))
                    {
                        var serializer = new DataContractJsonSerializer(typeof(T),settings);
                        returnValue = (T)serializer.ReadObject(jsonReader);
                    }
                }
                return returnValue;
            }
