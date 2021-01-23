    public async Task DoSomething(bool someValue)
    {
        if (IsTrue(someValue) && await SuperSlowThing().Length > 0)
        {
            Console.WriteLine("Did SuperSlowThing - result is " + asyncResult.Value.Result);
        }
        else
        {
            Console.WriteLine("Didn't do SuperSlowThing");
        }            
    }
