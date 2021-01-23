    If the values you are trying to deserialize are complex objects, you can adapt the solution from [Parsing large json file in .NET](https://stackoverflow.com/questions/32227436/parsing-large-json-file-in-net), enhance to handle the fact that your root JSON container might be an array or object.  
    Thus, instead, use:
        public static partial class JsonExtensions
        {
            public static IEnumerable<T> DeserializeValues<T>(Stream stream)
            {
                return DeserializeValues<T>(new StreamReader(stream));
            }
            public static IEnumerable<T> DeserializeValues<T>(TextReader textReader)
            {
                var serializer = JsonSerializer.CreateDefault();
                var reader = new JsonTextReader(textReader);
                reader.SupportMultipleContent = true;
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartArray)
                    {
                        while (reader.Read())
                        {
                            if (reader.TokenType == JsonToken.Comment)
                                continue; // Do nothing
                            else if (reader.TokenType == JsonToken.EndArray)
                                break; // Break from the loop
                            else
                                yield return serializer.Deserialize<T>(reader);
                        }
                    }
                    else if (reader.TokenType == JsonToken.StartObject)
                    {
                        while (reader.Read())
                        {
                            if (reader.TokenType == JsonToken.Comment)
                                continue; // Do nothing
                            else if (reader.TokenType == JsonToken.PropertyName)
                                continue; // Eat the property name
                            else if (reader.TokenType == JsonToken.EndObject)
                                break; // Break from the loop
                            else
                                yield return serializer.Deserialize<T>(reader);
                        }
                    }
                }
            }
        }
