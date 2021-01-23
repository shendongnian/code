    public class Foo
    {
        public int[] Values { get; set; }
    }
    public class FooConverter : CustomCreationConverter<Foo> 
    {
        public override Foo Create(Type objectType)
        {
            return new Foo();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);
            // Create target object based on JObject
            Foo target = Create(objectType);
            // get the properties inside 'bar' as a list of JToken objects
            IList<JToken> results = jObject["foo"]["bar"].Children().ToList();
            IList<int> values = new List<int>();
            // deserialize the tokens into a list of int values
            foreach (JToken result in results)
            {
                int val = JsonConvert.DeserializeObject<int>(result.First.ToString());
                values.Add(val);
            }
            target.Values = values.ToArray();
            return target;
        }
    }
