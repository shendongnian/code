    public abstract class MyBaseClass
    {
        private string var1;
        private string var2;
        private string var3;
        public MyBaseClass(string var1, string var2, string var3)
        {
            this.var1 = var1;
            this.var2 = var2;
            this.var3 = var3;
        }
        public bool Myfunc()
        {
            //code to do something with var1...var3
        }
    }
    public class DerivedClass : MyBaseClass
    {
        public DerivedClass()
            : base("var1value", "var2value", "var3value")
        {
            //constructor for derived class
        }
    }
    public class OtherDerivedClass : MyBaseClass
    {
        public OtherDerivedClass()
            : base("new", "newer", "newest")
        {
            //constructor for derived class
        }
    }
