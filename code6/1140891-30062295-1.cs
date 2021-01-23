    public class Example
    {
        [Test]
        public void Test()
        {
            var json =
                "[\r\n    {\r\n        \"Name\": \"PLAN-A\",\r\n        \"Type\": \"CalcInputTypes1\",\r\n        \"CS\": 1.1111,\r\n        \"CUSTOM_DATE1\": \"2015-05-22\",\r\n        \"CUSTOM_EARN1\": 65500.0,\r\n        \"GENDER\": \"Male\"\r\n    },\r\n    {\r\n        \"Name\": \"PLAN-B\",\r\n        \"Type\": \"CalcInputTypes2\",\r\n        \"CS\": 2.22222,\r\n        \"CUSTOM_DATE2\": \"2015-05-23\",\r\n        \"CUSTOM_EARN2\": 12000.0,\r\n        \"PROVINCE\": \"Ontario\"\r\n    }\r\n]";
            var result = JsonConvert.DeserializeObject<List<Item>>(json, new JsonItemConverter());
            Assert.That(result[0], Is.TypeOf<CalcInputTypes1>());
            Assert.That(((CalcInputTypes1)result[0]).Gender, Is.EqualTo("Male"));
            Assert.That(result[1], Is.TypeOf<CalcInputTypes2>());
            Assert.That(((CalcInputTypes2)result[1]).Province, Is.EqualTo("Ontario"));
        }
        public class JsonItemConverter : Newtonsoft.Json.Converters.CustomCreationConverter<Item>
        {
            public override Item Create(Type objectType)
            {
                throw new NotImplementedException();
            }
            public Item Create(Type objectType, JObject jObject)
            {
                var type = (string)jObject.Property("Type");
                switch (type)
                {
                    case "CalcInputTypes1":
                        return new CalcInputTypes1();
                    case "CalcInputTypes2":
                        return new CalcInputTypes2();
                }
                throw new ApplicationException(String.Format("The given type {0} is not supported!", type));
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                // Load JObject from stream
                var jObject = JObject.Load(reader);
                // Create target object based on JObject
                var target = Create(objectType, jObject);
                // Populate the object properties
                serializer.Populate(jObject.CreateReader(), target);
                return target;
            }
        }
        public abstract class Item
        {
            public string Type { get; set; }
        }
        public class CalcInputTypes1 : Item
        {
            [JsonProperty("GENDER")]
            public string Gender { get; set; }
        }
        public class CalcInputTypes2 : Item
        {
            [JsonProperty("PROVINCE")]
            public string Province { get; set; }
        }
    }
