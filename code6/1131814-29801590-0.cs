    public class Test
    {
         public int Process(string className, int a, int b)
         {
          // className="SumClass" or className="MultClass"
    
          return (int)(typeof (Test).GetMethod(className, BindingFlags.Instance | BindingFlags.Public)
            .Invoke(this, BindingFlags.InvokeMethod, null, new Object[] {a, b}, CultureInfo.CurrentCulture));
      
        }
    
        public int SumClass(int a, int b)
        {
          return a + b;
        }
    
        public int MultClass(int a, int b)
        {
          return a * b;
        }
    }
