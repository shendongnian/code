    static void _TestLogicForBeginInvoke(int i)
        {
            System.Threading.Thread.Sleep(10);
            System.Console.WriteLine("Tested");
        }
        static void _Callback(IAsyncResult iar)
        {
            System.Threading.Thread.Sleep(10); 
            
            System.Console.WriteLine("Callback " + iar.CompletedSynchronously);
        }
        static void TestBeginInvoke()
        {
            //Callback is written after Tested and NotDone.
            var call = new System.Action<int>(_TestLogicForBeginInvoke);
            //Start the call
            var callInvocation = call.BeginInvoke(0, _Callback, null);
            //Write output
            System.Console.WriteLine("Output");
            int times = 0;
            //Wait for the call to be completed a few times
            while (false == callInvocation.IsCompleted && ++times < 10)
            {
                System.Console.WriteLine("NotDone");
            }
            //Probably still not completed.
            System.Console.WriteLine("IsCompleted " + callInvocation.IsCompleted);
            //Can only be called once, should be called to free the thread assigned to calling the logic assoicated with BeginInvoke and the callback.
            call.EndInvoke(callInvocation);
        }//Callback 
