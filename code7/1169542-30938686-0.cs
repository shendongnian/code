    public class Expressions
    {
        public static System.Linq.Expressions.Expression<
          System.Func<int, int, int, int, int, bool>>
            DoSomething =
              (a, b, c, d, e) => false;
    }
    public class ExpressionTester
    {
        public ExpressionTester()
        {
            Expressions.DoSomething.Compile().Invoke(1, 2, 3, 4, 5);
        }
    }
