        protected T DeserializeNestedJsonStringWithReader<T>(string jsonString)
        {
            var reader = JsonReaderWriterFactory.CreateJsonReader(Encoding.Unicode.GetBytes(jsonString), System.Xml.XmlDictionaryReaderQuotas.Max);
            int elementCount = 0;
            while (reader.Read())
            {
                if (reader.NodeType == System.Xml.XmlNodeType.Element)
                    elementCount++;
                if (elementCount == 2) // At elementCount == 1 there is a synthetic "root" element
                {
                    var serializer = new DataContractJsonSerializer(typeof(T));
                    return (T)serializer.ReadObject(reader, false);
                }
            }
            return default(T);
        }
    This technique looks odd (parsing JSON with an `XmlReader`?), but with some extra work it should be possible to extend this idea to create [SAX-like parsing](https://en.wikipedia.org/wiki/Simple_API_for_XML) functionality for JSON that is similar to `SelectToken()`, skipping forward in the JSON until a desired property is found, then deserializing its value.
    For instance, to select and deserialize specific named properties, rather than just the first root property, the following can be used:
        public static class DataContractJsonSerializerExtensions
        {
            public static T DeserializeNestedJsonProperty<T>(string jsonString, string rootPropertyName)
            {
                // Check for count == 2 because there is a synthetic <root> element at the top.
                Predicate<Stack<string>> match = s => s.Count == 2 && s.Peek() == rootPropertyName;
                return DeserializeNestedJsonProperties<T>(jsonString, match).FirstOrDefault();
            }
            public static IEnumerable<T> DeserializeNestedJsonProperties<T>(string jsonString, Predicate<Stack<string>> match)
            {
                DataContractJsonSerializer serializer = null;
                using (var reader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(jsonString), XmlDictionaryReaderQuotas.Max))
                {
                    var stack = new Stack<string>();
                    while (reader.Read())
                    {
                        if (reader.NodeType == System.Xml.XmlNodeType.Element)
                        {
                            stack.Push(reader.Name);
                            if (match(stack))
                            {
                                serializer = serializer ?? new DataContractJsonSerializer(typeof(T));
                                yield return (T)serializer.ReadObject(reader, false);
                            }
                            if (reader.IsEmptyElement)
                                stack.Pop();
                        }
                        else if (reader.NodeType == XmlNodeType.EndElement)
                        {
                            stack.Pop();
                        }
                    }
                }
            }
        }
    See [Mapping Between JSON and XML](https://msdn.microsoft.com/en-us/library/bb924435.aspx) for details on how [`JsonReaderWriterFactory`](https://msdn.microsoft.com/en-us/library/system.runtime.serialization.json.jsonreaderwriterfactory.aspx) maps JSON to XML.
