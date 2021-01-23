    class GroupAttribute : Attribute
    {
        public string Name { get; set; }
        public GroupAttribute(string name)
        {
            Name = name;
        }
    }
    class GroupingConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject obj = new JObject();
            Type type = value.GetType();
            foreach (PropertyInfo pi in type.GetProperties())
            {
                JToken propVal = JToken.FromObject(pi.GetValue(value));
                GroupAttribute group = pi.GetCustomAttribute<GroupAttribute>();
                if (group != null)
                {
                    JObject groupObj = (JObject)obj[group.Name];
                    if (groupObj == null)
                    {
                        groupObj = new JObject();
                        obj.Add(group.Name, groupObj);
                    }
                    groupObj.Add(pi.Name, propVal);
                }
                else
                {
                    obj.Add(pi.Name, propVal);
                }
            }
            JObject wrapper = new JObject(new JProperty(type.Name, obj));
            wrapper.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override bool CanConvert(Type objectType)
        {
            // CanConvert is not called when a [JsonConverter] attribute is applied
            return false;
        }
    }
