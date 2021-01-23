    public class A<T>
    {
        public T Value { get; set; }
    }  
    
    List<A<dynamic>> list = new List<A<dynamic>>();
    
    list.Add(new A<dynamic> { Value = "Hello World" });
    list.Add(new A<dynamic> { Value = 100 });
    
    foreach(A<dynamic> item in list)
    {
        Console.WriteLine(item.Value);
    }
