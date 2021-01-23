    const string AppId = "Global\\1DDFB948-19F1-417C-903D-BE05335DB8A4"; // Unique per application 
    static void Main(string[] args) 
    { 
       using (Mutex mutex = new Mutex(false, AppId)) 
       { 
           if (!mutex.WaitOne(0)) 
           { 
               Console.WriteLine("2nd instance"); 
               return; 
           } 
           Console.WriteLine("Started"); 
           Console.ReadKey(); 
       } 
    }
