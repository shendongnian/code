       public class ClassNameBuilder
       {
            private ClassName _className;
    
    //default constructor;
            //store params in private fields
            public ClassNameBuilder(string enumValue, string user, string custom_class) 
            { 
               _className = new ClassName(EnumToString, new User(user), new CustomClass(custom_class));
    
            } 
            
            public void CallClassNameMethod1()
            {
                return _className.Method1()
            }
    
            public void CallClassNameMethod2()
            {
                return _className.Method2()
            }
    }
    
