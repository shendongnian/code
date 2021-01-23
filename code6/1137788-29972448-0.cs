    Expression<Func<TestContext>> parameter = () => this.TestContext;
    for (int i = 0; i < 1000000; i++)
    {
        this.SlowMethod(parameter);
    }
