        protected T DeserializeNestedJsonString<T>(string jsonString)
        {
            using (var memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(jsonString)))
            {
                var serializer = new DataContractJsonSerializer(typeof(Dictionary<string, T>));
                serializer.UseSimpleDictionaryFormat = true;
                var dictionary = (Dictionary<string, T>)serializer.ReadObject(memoryStream);
                if (dictionary == null || dictionary.Count == 0)
                    return default(T);
                else if (dictionary.Count == 1)
                    return dictionary.Values.Single();
                else
                {
                    throw new InvalidOperationException("Root object has too many properties");
                }
            }
        }
