    class CompositeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Composite));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Composite composite = (Composite)value;
            // Need to use reflection here because Elements is private
            PropertyInfo prop = typeof(Composite).GetProperty("Elements", BindingFlags.NonPublic | BindingFlags.Instance);
            List<Element> children = (List<Element>)prop.GetValue(composite);
            // if all children are leaves, output as an array
            if (children.All(el => el.GetType() != typeof(Composite)))
            {
                JArray array = new JArray();
                foreach (Element e in children)
                {
                    array.Add(JToken.FromObject(e, serializer));
                }
                array.WriteTo(writer);
            }
            else 
            {
                // otherwise use an object
                JObject obj = new JObject();
                if (composite.Name == "Root")
                {
                    obj.Add("Name", composite.Name);
                }
                foreach (Element e in children)
                {
                    obj.Add(e.Name, JToken.FromObject(e, serializer));
                }
                obj.WriteTo(writer);
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
