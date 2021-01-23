    class Program
    {
        static void Main(string[] args)
        {
            var someJson = @"
            [
                { ""quux"": ""abc"", ""inga"": ""def"" },
                { ""quux"": ""pqr"", ""inga"": ""stu"" }
            ]";
            JArray foosComingFromSomewhereElse = JArray.Parse(someJson);
            List<JObject> foos = new List<JObject>();
            foreach (var _foo in foosComingFromSomewhereElse.Children<JObject>())
            {
                JObject foo = new JObject();
                string bar = (string)_foo["quux"].Value<JToken>();
                string baz = (string)_foo["inga"].Value<JToken>();
                foo.Add("Baz", baz);
                foo.Add("Bar", bar);
                foos.Add(foo);
            }
            Console.WriteLine("--- Original FooBar JSON ---");
            string foobarJson = JsonConvert.SerializeObject(foos);
            Console.WriteLine(foobarJson);
            Console.WriteLine();
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("FooBar", foobarJson));
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new ClaimConverter() },
                Formatting = Formatting.Indented
            };
            Console.WriteLine("--- Serialized list of claims ---");
            string claimsJson = JsonConvert.SerializeObject(claims, settings);
            Console.WriteLine(claimsJson);
            Console.WriteLine();
            Console.WriteLine("--- Deserialized claim values ---");
            claims = JsonConvert.DeserializeObject<List<Claim>>(claimsJson, settings);
            foreach(Claim claim in claims)
                Console.WriteLine(claim.Value);
        }
    }
