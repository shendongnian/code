    class MyClass()
    {
       public MyClass()
       {
           _someProperty = "SomeValue";
       }
    
       // actually, backing field name will be different,
       // but it doesn't matter for this question
       private string _someProperty;
    
       public string SomeProperty
       { 
            get { return _someProperty; }
            set { _someProperty = value; }
       }
    }
