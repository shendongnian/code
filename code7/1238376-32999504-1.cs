    public abstract class MyBaseClass
    {
        protected string Var1 { get; private set; }
        protected string Var2 { get; private set; }
        protected string Var3 { get; private set; }
        public MyBaseClass(string var1, string var2, string var3)
        {
            this.Var1 = var1;
            this.Var2 = var2;
            this.Var3 = var3;
        }
        public bool Myfunc()
        {
            //code to do something with var1...var3
        }
    }
    [ ... ] 
    public class DerivedClass : MyBaseClass
    {
        public DerivedClass()
            : base("var1value", "var2value", "var3value")
        {
            // constructor for derived class
            // can acces protected members here
        }
    }
    [ ... ] 
