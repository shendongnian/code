    public static void doAsync(){
        var arr = stackalloc string[100];
        arr[0] = "hi";
         System.Threading.ThreadPool.QueueUserWorkItem(()=>{
               Thread.Sleep(10000);
               Console.Write(arr[0]);
         });
    }
