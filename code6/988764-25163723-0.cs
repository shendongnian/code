    public class A {
      public object Clone() {
        var type = GetType().GetConstructor(new[] { typeof(int), typeof(int) });
        return type.Invoke(new object[] { this.Min, this.Max });
      }
    }
