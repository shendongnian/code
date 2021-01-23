        public static JToken Normalize(this JToken token)
        {
            var result = token;
            switch (token.Type)
            {
                case JTokenType.Object:
                    var jObject = (JObject)token;
                    if (jObject != null && jObject.HasValues)
                    {
                        var newObject = new JObject();
                        foreach (var property in jObject.Properties().OrderBy(x => x.Name).ToList())
                        {
                            var value = property.Value as JToken;
                            if (value != null)
                            {
                                value = Normalize(value);
                            }
                            newObject.Add(property.Name, value);
                        }
                        return newObject;
                    }
                    break;
                case JTokenType.Array:
                    var jArray = (JArray)token;
                    if (jArray != null && jArray.Count > 0)
                    {
                        var normalizedArrayItems = jArray
                            .Select(x => Normalize(x))
                            .OrderBy(x => x.ToString(), StringComparer.Ordinal);
                        result = new JArray(normalizedArrayItems);
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
