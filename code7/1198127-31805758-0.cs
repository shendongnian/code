    static void Main(string[] args)
    {
        Test();
        Console.ReadLine();
    }
    static public async void Test() {
        Console.WriteLine("Will move...");
        await MoveAsync();
        //Will pause here while moving
        //Do next job here...
        Console.WriteLine("Move was completed. On to next job!!");
    }
    static public async Task MoveAsync()
    {
        await Task.Run(() => Move());
    }
    static public void Move()
    {
        //Do moving of file here....
        //System.IO.File.Move()
        System.Threading.Thread.Sleep(10000); // Simulate moving...
            
        //Completed?
        Console.WriteLine("Moved.");
    }
