    Delegate[] delegates = d1.GetInvocationList();
                foreach (Action d in delegates)
                    try
                    {
                        d1();
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("Exception Caught");
    
                    }
