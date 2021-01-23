    public void DoStuff(object input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }
    }
