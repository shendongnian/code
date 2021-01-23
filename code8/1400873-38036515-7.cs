    public static void Do<TTransition>()
        where TTransition : class, ITransition
    {
        ITest<ITransition> item = new SomeTest<TTransition>();
    }
