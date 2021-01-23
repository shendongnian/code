    class Program
    {
        static void Main(string[] args)
        {
            Del del = new Del(Notify);
            del.BeginInvoke("abc", callback, new object { });
        }
        private static void callback(IAsyncResult ar)
        {
           if (InvokeRequired)//if accessing from different thread
           {
            this.Invoke(new Action<Button>(enableButton), new object[] { homeBut });
           }
           Console.Write("Callback Triggerd. Thread Completed");
        }
        // Declare a delegate. 
        delegate void Del(string str);
        // Declare a method with the same signature as the delegate. 
        static void Notify(string name)
        {
            Console.WriteLine("Notification received for: {0}", name);
        }
    }
