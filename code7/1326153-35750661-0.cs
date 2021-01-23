    static void Main(string[] args)
    {
    	Console.WriteLine("1");
    	// thread 1, sync
    	byte[] dataToWrite = System.Text.ASCIIEncoding.ASCII.GetBytes("my custom data");
    	Task.Run(() =>
    	{
    		Console.WriteLine("2");
    		// aspetto un secondo
    		System.Threading.Thread.Sleep(1000);
    		// thread 2, async code
    		System.IO.File.WriteAllBytes(@"c:\temp\prova.txt", dataToWrite);
    		Console.WriteLine("2, end");
    	});
    
    	Console.WriteLine("3, exit");
    
    	Console.ReadLine();
    	// thread 1
    }
