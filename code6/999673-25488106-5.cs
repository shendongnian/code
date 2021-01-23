    public async Task DoSomething(bool someValue)
    {
        bool condition = false;
        
        if (IsTrue(someValue))
        {
            var result = await SuperSlowThing();
            if (result .Length > 0)
            {
                Console.Writeline(result);
            }
            condition = true;
        }
        
        if (!condition)
        {
            // ..
        }
    }
