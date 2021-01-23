     static void Main(string[] args)
     {
        TestFoo();
     }
     private static void TestFoo()
     {
         bool result;
         double sum;
         Foo((Expression<Func<double, bool>>)(x => x == 1.0), out result, 1.0);
         Foo((Expression<Func<double, double, double>>)((x, y) => x + y), out sum, 2.0, 3.0);
         Debug.Assert(result);
         Debug.Assert(sum == 5);
     }
     private static bool Foo<T>(LambdaExpression e, out T result, params object[] parameters)
     {
         result = default(T);
         if (e.Parameters.Count != parameters.Length)
             return false;
         result = (T)e.Compile().DynamicInvoke(parameters);
         return true;
     }
