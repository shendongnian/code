    public CustomClass DoSomething()
    {
        var data = new CustomClass();
        //....
        data.Data = list;
        data.Count = list.Count();
        return data;
    }
    public class CustomClass
    {
        public List<Class1> Data { get; set; }
        public int Count { get; set; }
    }
