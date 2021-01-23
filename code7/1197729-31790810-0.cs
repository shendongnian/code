     public class Test
     {
         public int PublicField;
         public int PublicProperty { get; set; }
     }
     ...
     public void MethodCall(ref int x) { ... }
     ...
     Test test = new Test();
     MethodCall(ref test.PublicField); // Fine
     MethodCall(ref test.PublicProperty); // Not fine
