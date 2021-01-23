    [JsonConverter(typeof(MyModelConverter))]
    public class MyModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("size")]
        public string[] Size { get; set; }
        [JsonProperty("weight")]
        public string Weight { get; set; }
    }
    public class TestClass
    {
        public static void Test()
        {
            string json = @"{
                ""name"" : ""widget"",
                ""details"" : {
                    ""size"" : [
                        ""XL"",""M"",""S"",
                    ],
                    ""weight"" : ""heavy""
                }
            }";
            var mod = JsonConvert.DeserializeObject<MyModel>(json);
            Debug.WriteLine(JsonConvert.SerializeObject(mod, Formatting.Indented));
        }
    }
