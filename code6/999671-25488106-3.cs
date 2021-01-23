    public async Task DoSomething(bool someValue)
    {
        bool condition = false;
        
        if (IsTrue(someValue))
        {
            if (await SuperSlowThing().Length > 0)
            {
                // ..
            }
            condition = true;
        }
        
        if (!condition)
        {
            // ..
        }
    }
