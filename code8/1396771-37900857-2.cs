        public class Configuration
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }
            [JsonIgnore]
            public MyEnumTypes Type { get; set; }
            [JsonIgnore]
            public OptionalType TypeAdditionalData { get; set; }
            [JsonProperty("type")]
            JToken SerializedType
            {
                get
                {
                    if (Type.GetCustomAttributeOfEnum<OptionalSettingsAttribute>() == null)
                    {
                        return JToken.FromObject(Type);
                    }
                    else
                    {
                        var dictionary = new Dictionary<MyEnumTypes, OptionalType>
                        {
                            { Type, TypeAdditionalData },
                        };
                        return JToken.FromObject(dictionary);
                    }
                }
                set
                {
                    if (value == null || value.Type == JTokenType.Null)
                    {
                        TypeAdditionalData = null;
                        Type = default(MyEnumTypes);
                    }
                    else if (value is JValue)
                    {
                        Type = value.ToObject<MyEnumTypes>();
                    }
                    else
                    {
                        var dictionary = value.ToObject<Dictionary<MyEnumTypes, OptionalType>>();
                        if (dictionary.Count > 0)
                        {
                            Type = dictionary.Keys.First();
                            TypeAdditionalData = dictionary.Values.First();
                        }
                    }
                }
            }
            [JsonProperty(PropertyName = "value")]
            public int Value { get; set; }
        }
