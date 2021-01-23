    class A { public static char c; }
    class B { public static char c; }
    class C { public static char c; }
    class D { public static char c; }
    var mychars = new char[] { 'a','b','c','d' };
    var types = new[] {
       typeof(A),
       typeof(B),
       typeof(C),
       typeof(D)
    };
    for (int i = 0; i < types.Length; i++) {
       var type = types[i];
       var field = type.GetField("c", BindingFlags.Public | BindingFlags.Static);
       if (field == null)
          throw new InvalidOperationException("No such field.");
       // pass null as instance for static members, since there's no instance
       field.SetValue(null, mychars[i]);
    }
