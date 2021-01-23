    public static void Main()
    {
        // All the code preceding the main while loop is here
        // Variable declarations etc.
        static string input = ""; // where the user command is stored
    
        //Setup a background worker
        backgroundWorker1.DoWork += BackgroundWorker1_DoWork; // This tells the worker what to do once it starts working
        backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;  // This tells the worker what to do once its task is completed
    
        backgroundWorker1.RunWorkerAsync(); // This starts the background worker
        
        // Your main loop
        while (fuel>0) 
        {
            moveAndGenerate();
        
            for (int i=0;i<road.GetLength(0); i++)
            {
                for (int j = 0; j < road.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0} ", road[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.WriteLine("Paliwo: "+ (fuel=fuel-5) + "%");
        
            moveAndGenerate();
            replaceArrays();            
        
            Thread.Sleep(1000);
            Console.Clear();
        }
        
        // This is what the background worker will do in the background
        private static void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Console.KeyAvailable == false)
            {
                System.Threading.Thread.Sleep(100); // prevent the thread from eating too much CPU time
            }
            else
            {
                input = Console.In.ReadLine();
            
                // Do stuff with input here or, since you can make it a static
                // variable, do stuff with it in the while loop.
            }
        }
        // This is what will happen when the worker completes reading
        // a user input; since its task was completed, it will need to restart
        private static void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs 
        {
            if(!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync(); // restart the worker
            }
        }
    }
