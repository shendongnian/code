    public class TestClass
    {
        public static void Test()
        {
            // receive json string
            string json = @"{
    ""abc"" : ""valueabc"",
    ""xyz"" : ""valueXYZ""
    }";
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[]
             { 
                 new exampleConverter()
             });
            var example = serializer.Deserialize<example>(json);
            Debug.Assert(example.abc == "valueabc" && example.xyz.SomeProperty == "valueXYZ"); // No assert
        }
    }
 
