    public enum MyClassDomain{One = 1, Two = 2, Three = 3}
    public class MyClass
    {
        private MyClassDomain intVal { get; set;)
        private MyClass() {}
        public static MyClass Make(int value) // <--- Factory to create instance
        { return new MyClass {Component = value}; }
        public int Component
        { 
            get { return (int) intval; }
            [private] set    //  <-- make this prIvate to make immutable
            {
                if(value < 1 || value > 3) 
                     throw new ArgumentException
                        ("Value out of range.");
                intVal = (MyClassDomain) value;
            }
    }
