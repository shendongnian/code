      var output = JsonConvert.DeserializeObject<List<Temp>>(dict);
                var dictionary = output.ToDictionary(x => x.Key, y => y.Value);
                public class Temp
                {
                    public string Key { get; set; }
                    public string Value { get; set; }
                }
