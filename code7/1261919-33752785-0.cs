    class Program
    {
    
        static List<Thread> lst = new List<Thread>();
            
        //static Thread t;
        static int count = 1;
        static void Main(string[] args)
        {
            System.Console.Title = "Thread Test";
    
            createThread();
    
            foreach (Thread t in lst) t.Start();
    
    
            //System.Console.WriteLine("Main Thread End...");
        }
    
    
    
        static void write()
        {
            while (true)
            {
    
                System.Console.Write(Thread.CurrentThread.Name);
                Thread.Sleep(500);
            }
        }
    
        static void createThread()
        {
            Random rnd = new Random();
    
            while (count<=5)
            {
                  
                Thread tt = new Thread(write);
                    
                if (rnd.Next(0,10)>=5)
                {
                    tt.Priority = ThreadPriority.Highest;
                }
                else
                {
    
                    tt.Priority = ThreadPriority.Lowest;
                }
    
                    
                    
                tt.Name = count.ToString();
                lst.Add(tt);
                count++;
            }
                
    
               
        }
    
    }
