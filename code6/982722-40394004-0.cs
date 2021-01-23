    Parallel.Invoke(
            () =>
                {
                   Console.WriteLine("Begin first task...");
                },  // close first Action
            async () =>
                  {
                      Console.WriteLine("Begin second task...");
                      while (true)
                            {
                             // HERE you are the code you need to be executed in infinite loop
                              await Task.Delay(60000);
                             }
                  }, //close second Action
            () =>
                {
                    Console.WriteLine("Begin third task...");
                } //close third Action
            ); //close parallel.invoke
            Console.WriteLine("Returned from Parallel.Invoke");
