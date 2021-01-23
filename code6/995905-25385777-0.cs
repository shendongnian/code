    Task.Factory.StartNew(() =>
    {
        for (int i = 0; i < maxTries - 1; i++)
        {
            try
            {
                return Foo();
            }
            catch
            { }
        }
        
        return Foo();
    });
