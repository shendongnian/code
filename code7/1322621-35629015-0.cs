    internal class ConventionBasedConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(JiraIssue).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var daat = JObject.Load(reader);
            var ret = new JiraIssue();
            foreach (var prop in ret.GetType().GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance))
            {
                var attr = prop.GetCustomAttributes(false).FirstOrDefault();
                if (attr != null)
                {
                    var propName = ((JsonPropertyAttribute)attr).PropertyName;
                    if (!string.IsNullOrWhiteSpace(propName))
                    {
                        var conventions = propName.Split('/');
                        if (conventions.Length == 3)
                        {
                            ret.Type = (string)((JValue)daat[conventions[0]][conventions[1]][conventions[2]]).Value;
                        }
                        
                        ret.Id = Convert.ToInt32(((JValue)daat[propName]).Value);
                    }                        
                }
            }
            return ret;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
    }
    var settings = new JsonSerializerSettings();
    settings.Converters.Add(new ConventionBasedConverter());
    var o = JsonConvert.DeserializeObject<JiraIssue>(s, settings);
