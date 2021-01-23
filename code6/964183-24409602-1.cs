    static void Main(string[] args)
            {
                
                    Task task = new Task(Work);
                    task.Start();
                var taskErrorHandler = task.ContinueWith(task1 =>
                    {
    
    
                        var ex = task1.Exception; 
                        
                        Console.WriteLine(ex.InnerException.Message);
                       
    
                    }, TaskContinuationOptions.OnlyOnFaulted);
    
                //here you  should put the readline in order to avoid the fast execution  of your main thread
                Console.ReadLine(); 
            }
    
            public static void Work()
            {
                throw new NotImplementedException();
            }
