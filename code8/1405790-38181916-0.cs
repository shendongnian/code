    static void Main(string[] args)
    {
        List<Foo> foos = new List<Foo>();
        foos.Add(new Foo() { ID = 1, Value = true });
        foos.Add(new Foo() { ID = 2, Value = false });
        foos.Add(new Foo() { ID = 3, Value = true });
    
        double Average = (foos.Count(F => F.Value) / Convert.ToDouble(foos.Count)) * 100;
    }
           
    
    public class Foo
    {
        public int ID { get; set; }
        public bool Value { get; set; }
    }
