    class MyClass()
    {
       public MyClass()
       {
           _someProperty = "SomeValue";
       }
    
       private string _someProperty;
    
       public string SomeProperty
       { 
            get { return _someProperty; }
            set { _someProperty = value; }
       }
    }
