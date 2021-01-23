    public async Task FooAsync(string x)
    {
        if (x == null)
        {
            throw new ArgumentNullException(nameof(x));
        }
        // Do some stuff including awaiting
    }
