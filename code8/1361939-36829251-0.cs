    static T Compose<T>(T source,
            IEnumerable<Func<T, T>> funcs,
            Func<T, bool> cond)
        {
            var func = funcs.Select(x => 
            {
                var ret = x;
                source = x(source);
                return ret;
            })
            .FirstOrDefault(y => cond(source));
            
            Console.WriteLine("Here is the Func that the condition succeeded on(null if none):");
            Console.WriteLine(func);
        
            return source;
        }
    
    void Main()
    {
        var funcs = new Func<int, int>[]
        {
            a => a + 1,
            a => a + 2,
            a => a + 3,
        };
    
        // Set this "cond = b => b == ?" value to want your  
        // func will succeed on. Since we are continuing to add 
        // to the source, the three Func's above will succeed on 
        // any of the following values: 1, 3, 6 and immediately exit 
        // ending any further enumeration via the ".FirstOrDefault"
        
        Func<int, bool> cond = b => b == 3;
        
        Console.WriteLine("Here are the list of Funcs:");
        Console.WriteLine(funcs);
        
        var result = Compose(0, funcs, cond);
        
        Console.WriteLine();
        Console.WriteLine("Below is the actual result of the source after being ");
        Console.WriteLine("acted on by the Funcs. If no Func matched the condition,");
        Console.WriteLine("all Funcs acted on the source so the source will return 6.");
        Console.WriteLine("That means;");
        Console.WriteLine("If the first Func matched (aka cond = b => b == 1), the source will return 1.");
        Console.WriteLine("If the second Func matched (aka cond = b => b == 3), the source will return 3.");
        Console.WriteLine("If the third Func matched  (aka cond = b => b == 6), the source will return 6. Same ");
        Console.WriteLine("as matching no Func because all Funcs were applied. However, see above that 'null'");
        Console.WriteLine("was displayed for the 'Here is the Func that the condition succeeded on' when ");
        Console.WriteLine("you set the condition value to an int other than 1, 3, or 6.");
        Console.WriteLine();
        Console.WriteLine("Actual result of the source after being acted on by the Funcs retuned:");
        Console.WriteLine(result);
    }
