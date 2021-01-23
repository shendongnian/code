    using Newtonsoft.Json;
    using Newtonsoft.Json.Schema;
    using Newtonsoft.Json.Schema.Generation;
    
    public class JSSchemaTest
    {
        class TestClass
        {
            public float field = 20;
        }
        JSchemaGenerator generator = new JSchemaGenerator();
        JsonSerializer serializer = new JsonSerializer();
    
        public void Run()
        {
            JSchema schema = generator.Generate(typeof(TestClass));
            JsonTextReader reader = new JsonTextReader(new System.IO.StringReader("{field: 2}"));
            JSchemaValidatingReader validatingReader = new JSchemaValidatingReader(reader);
            validatingReader.Schema = schema;
            TestClass res = serializer.Deserialize<TestClass>(validatingReader);
        }
    }
