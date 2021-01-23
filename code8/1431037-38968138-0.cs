    public class A : Dictionary<string, object>
    {
        public A(IDictionary<string, object> dictionary) : base(dictionary)
        { }
    }
    Dictionary<string , object> d=new Dictionary<string , object>();
    
    A a= new A(d);
