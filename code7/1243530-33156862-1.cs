    [DataContract]
    class TestObject
    {
        [LegacyDataMemberNames("alpha", "omega")]
        [DataMember(Name = "a")]
        public int A { get; set; }
    }
    public static class JsonExtensions
    {
        public static void RenameProperty(this JObject obj, string oldName, string newName)
        {
            if (obj == null)
                throw new NullReferenceException();
            var property = obj.Property(oldName);
            if (property != null)
            {
                property.Replace(new JProperty(newName, property.Value));
            }
        }
    }
    public class TestClass
    {
        public static void Test()
        {
            try
            {
                TestInner();
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.ToString()); // No assert
                throw;
            }
        }
        public static void TestInner()
        {
            var test = new TestObject { A = 42 };
            var settings = new JsonSerializerSettings { ContractResolver = LegacyPropertyResolver.Instance };
            var json = JObject.FromObject(test, JsonSerializer.CreateDefault(settings));
            if (json.SelectToken("alpha") != null || json.SelectToken("omega") != null)
                throw new InvalidOperationException("Failed serialization");
            Test(test, json);
            json.RenameProperty("a", "alpha");
            Test(test, json);
            json.RenameProperty("alpha", "omega");
            Test(test, json);
        }
        private static void Test(TestObject test, JObject json)
        {
            var test1 = json.ToObject<TestObject>(JsonSerializer.CreateDefault(new JsonSerializerSettings { ContractResolver = LegacyPropertyResolver.Instance }));
            if (test1.A != test.A)
                throw new InvalidOperationException("Failed deserialization");
            Console.WriteLine("Successfully deserialized: " + json.ToString(Formatting.None));
            Debug.WriteLine("Successfully deserialized: " + json.ToString(Formatting.None));
        }
    }
