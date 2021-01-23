    class TestObject
    {
            
        public int Field1 { get; set; }
        public int Field2 { get; set; }
        public int Field3 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string exampleJson = @"{ ""Field1"": 1, ""Field4"": 1 }";
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;
            settings.ContractResolver = new ContractResolver();
            settings.Error = Error;
            try
            {
                TestObject obj = JsonConvert.DeserializeObject<TestObject>(exampleJson, settings);
                Console.WriteLine("Object had no errors");
            }
            catch (Exception)
            {
                Console.WriteLine("Object had errors");
            }
        }
        private static void Error(object sender, ErrorEventArgs errorEventArgs)
        {
            errorEventArgs.ErrorContext.Handled = true;
            Console.WriteLine(errorEventArgs.ErrorContext.Path + " had " + errorEventArgs.ErrorContext.Error.Message);
        }
    }
    internal class ContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty res = base.CreateProperty(member, memberSerialization);
            res.Required = Required.AllowNull;
            return res;
        }
    }
