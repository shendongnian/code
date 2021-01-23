    public class MyConverter : JsonConverter {
        // ... other stuff, see the blog article
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            if (jo["MyCustomType"].Value<string>() == "MyConcreteProcessConfiguration")
                return jo.ToObject<MyConcreteProcessConfiguration>(serializer);
            if (jo["MyCustomType"].Value<string>() == "MyOtherConcreteProcessConfiguration")
                return jo.ToObject<MyOtherConcreteProcessConfiguration>(serializer);
           return null;
        }
    }
