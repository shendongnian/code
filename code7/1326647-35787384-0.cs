    public static class JsonExtensions
    {
    	public static Dictionary<string, object> Flatten(this JToken token)
        {
            var dict = new Dictionary<string, object>();
            Flatten(token, dict);
            return dict;
        }
    
        private static void Flatten(JToken token, Dictionary<string, object> dict)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    foreach (JProperty prop in token.Children<JProperty>())
                    {
                        Flatten(prop.Value, dict);
                    }
                    break;
    
                case JTokenType.Array:
                    foreach (JToken child in token.Children())
                    {
                        Flatten(child, dict);
                    }
                    break;
    
                default:
                    dict.Add(token.Path, ((JValue)token).Value);
                    break;
            }
        }
    }
