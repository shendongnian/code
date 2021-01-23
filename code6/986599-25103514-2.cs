    public class myClass2 : myClass
    {
    
        public myClass2() { }
    
        public int MyKey
        {
            get{ return base.GetKey();}
            set{ base.SetKey(value);}
        }
    
        public string MyValue
        {
            get{return base.GetValue();}
            set{base.SetValue(value);}
        }
    }
