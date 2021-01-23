    public class Foo
    {
        public string SomeLengthyCSharpPropertyName { get; set; }
        public string DefaultNotIgnored { get; set; }
        [JsonIgnore]
        public string DefaultIgnored { get; set; }
    }
    public class TestClass
    {
        public static void Test()
        {
            var foo = new Foo { SomeLengthyCSharpPropertyName = "SomeLengthyCSharpPropertyName", DefaultIgnored = "DefaultIgnored", DefaultNotIgnored = "DefaultNotIgnored" };
            var resolver = new OverrideContractResolver(new Dictionary<MemberInfo, JsonPropertyOverride> { 
                { typeof(Foo).GetProperty("SomeLengthyCSharpPropertyName"), new JsonPropertyOverride { PropertyName = "c"  } }, 
                { typeof(Foo).GetProperty("DefaultNotIgnored"), new JsonPropertyOverride { Ignored = true  } }, 
                { typeof(Foo).GetProperty("DefaultIgnored"), new JsonPropertyOverride { Ignored = false  } }, 
            });
            var settings = new JsonSerializerSettings { ContractResolver = resolver };
            var json = JsonConvert.SerializeObject(foo, settings); // Outputs {"c":"SomeLengthyCSharpPropertyName","DefaultIgnored":"DefaultIgnored"}
            Debug.WriteLine(json);
            var expectedJson = @"{ ""c"": ""SomeLengthyCSharpPropertyName"", ""DefaultIgnored"": ""DefaultIgnored"" }";
            var ok = JToken.DeepEquals(JToken.Parse(json), JToken.Parse(expectedJson));
            Debug.Assert(ok); // No assert
            var foo2 = JsonConvert.DeserializeObject<Foo>(json, settings);
            var ok2 = foo2.DefaultIgnored == foo.DefaultIgnored && foo2.SomeLengthyCSharpPropertyName == foo.SomeLengthyCSharpPropertyName;
            Debug.Assert(ok2); // No assert
        }
    }
