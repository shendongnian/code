    public class MyType
    {
        public string A { get; set; }
    }
    var myCast = new DynamicCast<MyType>();
    dynamic dyn = ExpandoObject();
    dyn.A = "Hello";
    var myType = myCast.Cast(dyn);
    Console.WriteLine(myType.A); // prints 'Hello'
