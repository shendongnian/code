    [AttributeUsage(Inherited=true, AllowMultiple=true, Inherited=true)]
    public class MyAttribute : Attribute
    {
        public bool Enabled { get; set; }
        
        public MyAttribute() { }
    
        public void SomethingTheAttributeDoes()
        {
            if (this.Enabled) this._DoIt)();
        }
    }
    
    public class MyObject
    {
        [MyAttribute(Enabled = true)]
        public double SizeOfIndexFinger { get; set; }
    }
    
    public class ExtendedObject : MyObject
    {
        [MyAttribute(Enabled = false)]
        public new double SizeOfIndexFinger { get; set; }
    }
