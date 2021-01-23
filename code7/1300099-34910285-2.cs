    async static Task<int> test(){ 
        Console.WriteLine("{0}: Start 3", DateTime.Now);
        await Task.Delay(3000);
        return 3; 
    }
    
            List<Task<int>> tasks2 = new List<Task<int>> {
               new Task<int>( delegate{ return test().Result;}),
                new Task<int>( delegate { Console.WriteLine("{0}: Start 3", DateTime.Now); Task.Delay(3000).Wait(); return 3; } ),
                new Task<int>( delegate { Console.WriteLine("{0}: Start 1", DateTime.Now); Task.Delay(1000).Wait(); return 1; } ),
                };
    
    foreach (var task in tasks2)
    {
            task.Start();
    }
