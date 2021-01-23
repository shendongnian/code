    public struct MyStruct
        {
            public string StringPropertie;
            public int IntPropertie;
            public float floatPropertie;
            public DateTime DatetimePropertie;
            public bool boolPropertie;
        }
    
        public class MyClass
        {
            public MyClass()
            {
                  MyStruct property ;
                  //...
                  string str = property.StringPropertie;
                 
            }
       }
