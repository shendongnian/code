    internal enum ArithmeticFunction
    {
       Add,
       Subtract,
       Multiply,
       Divide,
       Min,
       Max,
    }
    
    internal static class FunctionMap
    {
       private static readonly Dictionary<ArithmeticFunction, Func<int, int, int>> s_map;
    
       static FunctionMap()
       {
          s_map = new Dictionary<ArithmeticFunction, Func<int, int, int>>();
    
          s_map[ArithmeticFunction.Add] = (x, y) => x + y;
          s_map[ArithmeticFunction.Subtract] = (x, y) => x - y;
          s_map[ArithmeticFunction.Multiply] = (x, y) => x * y;
          s_map[ArithmeticFunction.Divide] = (x, y) => x / y;
          s_map[ArithmeticFunction.Min] = System.Math.Min;
          s_map[ArithmeticFunction.Max] = System.Math.Max;
       }
    
       //Don't allow callers access to the core map.  Return them a copy instead.
       internal static Dictionary<ArithmeticFunction, Func<int, int, int>> GetCopy()
       {
          return new Dictionary<ArithmeticFunction, Func<int, int, int>>(s_map); 
       }
    
       internal static int Compute(ArithmeticFunction op, int x, int y)
       {
          return s_map[op](x, y);
       }
    
    }
    static void Main(string[] args)
    {
    
       System.Diagnostics.Trace.WriteLine("Example 1:");
       System.Diagnostics.Trace.WriteLine(FunctionMap.Compute(ArithmeticFunction.Add, 12, 4));
       System.Diagnostics.Trace.WriteLine(FunctionMap.Compute(ArithmeticFunction.Subtract, 12, 4));
       System.Diagnostics.Trace.WriteLine(FunctionMap.Compute(ArithmeticFunction.Multiply, 12, 4));
       System.Diagnostics.Trace.WriteLine(FunctionMap.Compute(ArithmeticFunction.Divide, 12, 4));
       System.Diagnostics.Trace.WriteLine(FunctionMap.Compute(ArithmeticFunction.Min, 12, 4));
       System.Diagnostics.Trace.WriteLine(FunctionMap.Compute(ArithmeticFunction.Max, 12, 4));
    
       var safeCopy = FunctionMap.GetCopy();
       System.Diagnostics.Trace.WriteLine("Example 2:");
       System.Diagnostics.Trace.WriteLine(safeCopy[ArithmeticFunction.Add](72, 9));
       System.Diagnostics.Trace.WriteLine(safeCopy[ArithmeticFunction.Subtract](72, 9));
       System.Diagnostics.Trace.WriteLine(safeCopy[ArithmeticFunction.Multiply](72, 9));
       System.Diagnostics.Trace.WriteLine(safeCopy[ArithmeticFunction.Divide](72, 9));
       System.Diagnostics.Trace.WriteLine(safeCopy[ArithmeticFunction.Min](72, 9));
       System.Diagnostics.Trace.WriteLine(safeCopy[ArithmeticFunction.Max](72, 9));
