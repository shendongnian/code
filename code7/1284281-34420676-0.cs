    public class MyClass
    {
        public string Label { get; set; }
        public List<int> Numbers { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.AddProfile<MyProfile>(); // add the profile
            MyClass obj1 = new MyClass { Label = "AutoMapper Test" };
            MyClass obj2 = new MyClass();
            Mapper.Map(obj1, obj2);
            Debug.Assert(obj2 != null && obj2.Numbers == null, "FAILED");
        }
    }
    public class MyProfile : Profile
    {
        protected override void Configure()
        {
            AllowNullCollections = true;
            CreateMap<MyClass, MyClass>();
            // add other maps here.
        }
    }
