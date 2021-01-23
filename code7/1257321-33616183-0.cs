    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.Reflection;
    
    namespace ConsoleApplication8
    {
        public class model
        {
            [JsonProperty(PropertyName = "id")]
            public long ID { get; set; }
    
            [JsonProperty(PropertyName = "some_string")]
            public string SomeString { get; set; }
        }
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                var model = new model();
    
                var result = string.Empty;
    
                PropertyInfo[] props = typeof(model).GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    foreach (object attr in prop.GetCustomAttributes(true))
                    {
                        result += (attr as JsonPropertyAttribute).PropertyName;
                    }
                }
            }
        }
    }
