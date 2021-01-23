    public class MyClass
    {
        public Int32 value1 { get; set; }
        public String value2 { get; set;}
    } 
    public static string WriteResult2(MyObject obj)
    {
        return "Result: value=" + obj.value1 + " name=" + obj.value2 ;
    }
