    static void Main(string[] args)
    {
        TestFoo();
    }
    private static Tuple<bool, Exception> Foo<T>(LambdaExpression expression, out T result, params object[] parameters)
    {
        bool succesful = false;
        result=default(T);
        Exception invokeException = null;
        if (expression.Parameters.Count == parameters.Length)
        {
            try
            {
                result = (T)expression.Compile().DynamicInvoke(parameters);
                succesful = true;
            }
            catch (Exception e)
            {
                invokeException = e;
            }
        }
        return new Tuple<bool, Exception>(succesful, invokeException);
    }
    private static void TestFoo()
    {
        bool result;
        double sum;
        var succesful = Foo((Expression<Func<bool>>)(() => true), out result);
        Debug.Assert(succesful.Item1);
        Debug.Assert(result);
        Debug.Assert(succesful.Item2 == null);
        succesful = Foo((Expression<Func<double, bool>>)(x => x == 1.0), out result, 1.0);
        Debug.Assert(succesful.Item1);
        Debug.Assert(result);
        Debug.Assert(succesful.Item2 == null);
        succesful = Foo((Expression<Func<double, double, double>>)((x, y) => x + y), out sum, 2.0, 3.0);
        Debug.Assert(succesful.Item1);
        Debug.Assert(sum == 5);
        Debug.Assert(succesful.Item2 == null);
        succesful = Foo((Expression<Func<double, double, double>>)((x, y) => x + y), out sum, 2.0, new object());
        Debug.Assert(!succesful.Item1);
        Debug.Assert(succesful.Item2 is ArgumentException);
    }
