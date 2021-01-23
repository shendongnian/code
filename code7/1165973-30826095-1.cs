    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    //[DataContract] -- also works.
    public class TestClass
    {
        public string Query { get; set; } // Not serialized by default since this class has opt-in serialization.
        public static void Test()
        {
            var test = new TestClass { Query = "foo bar" };
            var json = JsonConvert.SerializeObject(test, Formatting.Indented);
            Debug.Assert(!json.Contains("foo bar")); // Assert the initial value was not serialized -- no assert.
            Debug.WriteLine(json);
            var settings = new JsonSerializerSettings { ContractResolver = new OptOutContractResolver() };
            JsonConvert.PopulateObject("{ 'Query': 'test' }", test, settings);
            Debug.Assert(test.Query == "test"); // Assert the value was populated -- no assert.
            Debug.WriteLine(JsonConvert.SerializeObject(test, Formatting.Indented, settings));
        }
    }
