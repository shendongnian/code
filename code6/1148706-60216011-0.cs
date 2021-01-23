    using System.Timers;    You can use directly
 
    static void Main(string[] args)
                {
                    Timer q = new Timer(10000);            
                    q.Elapsed += Q_Tick;
                    q.Start();
                    
                    
                    Console.ReadKey();
                }      
        
                private static void Q_Tick(object sender, EventArgs e)
                {
                    Console.WriteLine(DateTime.Now);
                }
