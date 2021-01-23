    void Main()
    {
      Vars.a.ToString().Dump();
      Vars.b.ToString().Dump();
      Vars.c.ToString().Dump();
      Vars.d.ToString().Dump();
    }
    
    public class MyVar
    {
        public override string ToString()
        {
            var field = typeof(Vars)
                        .GetFields()
                        .Where(i => object.ReferenceEquals(i.GetValue(null), this))
                        .FirstOrDefault();
            
            return field == null ? "Unknown" : field.Name;
        }
    }
    
    public class Vars
    {
        public static MyVar a = new MyVar(); //ToString() returns "a" or "Vars.a"
        public static MyVar b = new MyVar(); //ToString() returns "b" or "Vars.b"
        public static MyVar c = new MyVar(); //ToString() returns "c" or "Vars.c"
        public static MyVar d = new MyVar(); //ToString() returns "d" or "Vars.d"
    }
