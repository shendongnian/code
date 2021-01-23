    internal class Program
    {
        private static void Main(string[] args)
        {
            string json = "{\"name\":\"Chris\",\"home\":[],\"children\":[{\"name\":\"Belle\"},{\"name\":\"O\"}]}";
    
            RootObject result = JsonConvert.DeserializeObject<RootObject>(json);
                
            Console.ReadLine();
        }
    }
    
    public class Child
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
    
    public class RootObject
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    
        [JsonProperty(PropertyName = "home")]
        public List<object> Home { get; set; }
            
        [JsonProperty(PropertyName = "children")]
        public List<Child> ChildrenCollection { get; set; }
    
        [JsonIgnore]
        public string Children
        {
            get
            {
                // You can format the result the way you want here. 
                return string.Join(",", ChildrenCollection.Select(x => x.Name));
            }
        }
    }
