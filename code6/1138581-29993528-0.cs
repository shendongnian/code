    public static Expression Exp = null;
    public static void Foo(Expression<Func<bool>> exp)
    {
        if (Exp == null)
        {
            Exp = exp;
        }
        else
        {
            Console.WriteLine(object.ReferenceEquals(Exp, exp));
        }
    }
