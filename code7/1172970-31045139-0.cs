    static void Main(string[] args)
    {
        RunIt();
    
        Console.WriteLine("Waiting....");
        Console.ReadLine();
    }
    static async void RunIt()
    {
        Task t = new Task
        (
            () =>
            {
                Thread.Sleep(3000); 
                Console.WriteLine("Ended the task");
            }
        );    
        t.Start();  
        await t;
        Console.WriteLine("After await");
    }
