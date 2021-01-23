    public static void BC_AddTakeCompleteAdding()
    {
        using (BlockingCollection<int> bc = new BlockingCollection<int>(1))
        {
    
            // Spin up a Task to populate the BlockingCollection  
            using (Task t1 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    if (bc.Count == 0)
                    {
                        bc.Add(i);
                        Debug.WriteLine("  add  " + i.ToString());
                    }
                    else
                    {
                        Debug.WriteLine("  skip " + i.ToString());
                    }
                    Thread.Sleep(30);
                }
                bc.CompleteAdding();
            }))
            {
    
                // Spin up a Task to consume the BlockingCollection 
                using (Task t2 = Task.Factory.StartNew(() =>
                {
                    try
                    {
                        // Consume consume the BlockingCollection 
                        while (true)
                        {
                            Debug.WriteLine("take " + bc.Take());
                            Thread.Sleep(100);
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        // An InvalidOperationException means that Take() was called on a completed collection
                        Console.WriteLine("That's All!");
                    }
                }))
    
                    Task.WaitAll(t1, t2);
            }
        }
    }
