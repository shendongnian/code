    [Theory, AutoData]
    public void MyTest(Generator<int> g, string foo)
    {
        var uniqueIntegers = g.Distinct().Take(10);
        // more test code goes here...
    }
