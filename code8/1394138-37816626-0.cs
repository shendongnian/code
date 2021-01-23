     using System.Reflection;
     ...
     void SomeMethod(Base obj) { 
       // Declared type, "Base" - since "Base obj" is declared in the method
       Type baseType = MethodInfo.GetCurrentMethod().GetParameters()[0].ParameterType;
       // Actual type, "Derived1", "Derived2" - actually passed as parameter
       Type derivedType = obj.GetType();
       ...
     }
