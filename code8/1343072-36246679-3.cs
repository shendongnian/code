    public class GenericEntity<T> where T : BaseClass 
        {
       public T Property { get; set; }
    }
     
    public class BaseClass {
    }
    class Derived1 : BaseClass
    {
        public int Age { get; set; }
    }
     
    class Derived2 : BaseClass {
        public string Name { get; set; }
    }
    ....
    static void Main()
        {
            Derived1 d1 = new Derived1 {Age = 23};
            GenericEntity<Derived1> entity = new GenericEntity<Derived1> {Property = d1};
            var data = JsonConvert.SerializeObject(entity, new JsonSerializerSettings() {
                TypeNameHandling = TypeNameHandling.All
            });
            var baseEntity = JsonConvert.DeserializeObject<GenericEntity<Derived1>>(data, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            });
    }
