    namespace Parent
    {
       class Program
        {
           static void Main(string[] args)
            {
               using (var childReadyEh =new EventWaitHandle(false, EventResetMode.AutoReset,"childIsReady"))
                {
                   Process.Start("child.exe");
                    childReadyEh.WaitOne();
                }
     
               using (var childSignalEh =EventWaitHandle.OpenExisting("childSignal"))
                {
                    childSignalEh.WaitOne();
                }
     
               Console.WriteLine("Signal is recieved");
               Console.ReadKey();
            }
        }
    }
    
    namespace Child
    {
       class Program
        {
           static void Main(string[] args)
            {
               EventWaitHandle childSignalEh =null;
               using (var childReadyEh =EventWaitHandle.OpenExisting("childIsReady"))
                {
                    childSignalEh =new EventWaitHandle(false, EventResetMode.AutoReset,"childSignal");
                    childReadyEh.Set();
                }
               Console.WriteLine("Anykey to send a signal to parent");
                Console.ReadKey();
    
                childSignalEh.Set();
                childSignalEh.Dispose();
     
               Console.WriteLine("Signal is sent");
               Console.ReadKey();
            }
        }
    }
