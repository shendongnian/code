      public class Test {
        public int MyProp {
          get;
          set;
        }
      }
...
      string report = String.Join(Environment.NewLine, typeof(Test)
        .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
        .Select(field => field.Name));
    
      Console.Write(report);
