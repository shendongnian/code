    class MyClass
    {
        public FilterType filter_type { get; set; } 
    }
    
    public class Program
    {
        public static void Main()
        {
            var myClass = JsonConvert.DeserializeObject<MyClass>(json);
            var itsUnsafe = myClass.filter_type == FilterType.@unsafe;
            Console.WriteLine(itsUnsafe);
        }
        
        public static string json = @"{
      ""filter"": ""...."",
      ""filter_type"": ""unsafe"",
      ""included_fields"": [
        ""..."",
        ""...."",
        "".....""
      ]
    }";
    }
