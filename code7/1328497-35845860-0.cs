    public void CallSeed()
    {
        using (var c = new Context()) // create your context
        {
            Seed(c);
        }
    }
