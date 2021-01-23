    new SimpleLoop(0, i => i <= 12, 1, delegate (int i)
    {
        try
        {
            if (i == 5)
            { throw new ArgumentException(); }//raise an other Exception 
            if (i > 10)
            { SimpleLoop.Break(); }
              Console.WriteLine(i);
        }
        catch (Exception exception)//Catching every Exception, it would be better to catch just ArgumentExceptions
        {
            if (exception.GetType() == typeof(BreakException))
            { SimpleLoop.Break(); }//Call Break again
            Console.WriteLine("Error at " + i);
        }
    });
