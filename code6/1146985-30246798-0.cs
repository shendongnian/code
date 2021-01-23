    public class Foo
    {
        public string key;
        public float value;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var data = "[{\"key\":\"tf\",\"value\":221},{\"key\":\"ba\",\"value\":108}]";
            var addValue = "[{\"key\":\"tf\",\"value\":2},{\"key\":\"ba\",\"value\":1.5}]";
            var obj1 = JsonConvert.DeserializeObject<List<Foo>>(data);
            var obj2 = JsonConvert.DeserializeObject<List<Foo>>(addValue);
            var new_obj = (from a in obj1
                           from b in obj2
                           where a.key == b.key
                           select new Foo { key = a.key, value = a.value + b.value }).ToList();
            Console.WriteLine(JsonConvert.SerializeObject(new_obj, Formatting.Indented));
            
        }
    }
