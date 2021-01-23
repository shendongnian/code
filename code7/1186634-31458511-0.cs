    namespace StackOverFlowTest
    {
      using System;
    
      class BaseClass
      {
        public int BaseClassMethod(int x)
        {
          return x * x;
        }
      }
    
      class DerivedClass : BaseClass
      {
      }
    
      class Program
      {
        static void Main()
        {
          var derivedType = typeof(DerivedClass);
          var baseType = typeof(BaseClass);
    
          var method = baseType.GetMethod("BaseClassMethod");
    
          var derivedInstance = Activator.CreateInstance(derivedType);
    
          var result = method.Invoke(derivedInstance, new object[] { 42 });
    
          Console.WriteLine(result);
          Console.ReadLine();
        }
      }
    }
