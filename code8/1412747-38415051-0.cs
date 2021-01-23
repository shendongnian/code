    using System;
    using static System.Console;
    static class Program {
      static void Test1(Func<int?> f)     { WriteLine("Test1(Func<int?>)");     }
      static void Test1(Func<decimal?> f) { WriteLine("Test1(Func<decimal?>)"); }
      static void Test2(Func<decimal?> f) { WriteLine("Test2(Func<decimal?>)"); }
      static void Test2(Func<int?> f)     { WriteLine("Test2(Func<int?>)");     }
      static void Main() {
        Test1(() => null);
        Test2(() => null);
      }
    }
