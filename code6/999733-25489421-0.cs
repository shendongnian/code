    public class MyClass
    {
        public string Test { get; set; }
        public static MyClass operator ++(MyClass myclass)
        {
            myclass.Test += " test";
            return myclass;
        }
    }
