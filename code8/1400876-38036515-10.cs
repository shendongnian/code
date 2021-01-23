    public static void Do<TTransition>()
        where TTransition : ITransition
    {
        ITest<ITransition> item = new SomeTest<TTransition>();
    }
