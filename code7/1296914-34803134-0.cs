       public static void ThreadAbortDemo(int sleeptime)
        {
            int[] collection = new int[10];
            foreach (var item in collection)
            {
                System.Threading.Thread thread = new System.Threading.Thread(() =>
                {
                    try
                    {
                        // do your stuff with item
                    }
                    catch (System.Threading.ThreadAbortException)
                    {
                        // this thread is disposed by thread.Abort() statement
                        // do some stuff here before exit this thread
                    }
                });
                thread.Start();
                System.Threading.Timer timer = new System.Threading.Timer((o) =>
               {
                   try
                   {
                       thread.Abort(o);
                   }
                   catch
                   {
                       // the thread is done before Abort statement called
                   }
               },new object(),sleeptime,System.Threading.Timeout.Infinite);
            }
        }
