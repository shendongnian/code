    static void Main(string[] args)
    {
        TestFoo();
    }
    private static bool Foo<T>(LambdaExpression expression, out T result, out Exception invokeException, params object[] parameters)
    {
        result=default(T);
        invokeException = null;
        if (expression.Parameters.Count != parameters.Length)
            return false;
        try
        {
            result = (T)expression.Compile().DynamicInvoke(parameters);
            return true;
        }
        catch (Exception e)
        {
            invokeException = e;
        }
        return false;
    }
    private static void TestFoo()
    {
        bool result;
        double sum;
        Exception e;
        var succesful = Foo((Expression<Func<bool>>)(() => true), out result, out e);
        Debug.Assert(succesful);
        Debug.Assert(result);
        Debug.Assert(e == null);
        succesful = Foo((Expression<Func<double, bool>>)(x => x == 1.0), out result, out e, 1.0);
        Debug.Assert(succesful);
        Debug.Assert(result);
        Debug.Assert(e == null);
        succesful = Foo((Expression<Func<double, double, double>>)((x, y) => x + y), out sum, out e, 2.0, 3.0);
        Debug.Assert(succesful);
        Debug.Assert(sum == 5);
        Debug.Assert(e == null);
        succesful = Foo((Expression<Func<double, double, double>>)((x, y) => x + y), out sum, out e, 2.0, new object());
        Debug.Assert(!succesful);
        Debug.Assert(e is ArgumentException);
    }
