    .ContinueWith(t => 
                  {
                     if(t.Exception != null)
                     {
                        // log error
                     }
                     else
                     {
                        Console.WriteLine("Completed download.")));
                     });
