    public class MyVar
    {
      public static readonly MyVar a = new MyVar(nameof(a));
      public static readonly MyVar b = new MyVar(nameof(b));
      public static readonly MyVar c = new MyVar(nameof(c));
      public static readonly MyVar d = new MyVar(nameof(d));
      private readonly string name;
      private MyVar(string name) { this.name = name; }
      override string ToString() { return this.name; }
    }
