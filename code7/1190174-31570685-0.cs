    public void Foo(IReadOnlyCollection<string> input)
    {
    }
    public void Main(string[] args)
    {
        Foo(new Stack<string>());
    }
