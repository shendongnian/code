    private static AutoResetEvent m_event = new AutoResetEvent(false);
    private static void Main(string args[])
    {
       new Thread(() =>
       {
          m_event.WaitOne();
          Console.WriteLine("Signal received from main");
       }).Start();
       Console.WriteLine("Sending signal");
       m_event.Set();
       
       m_event.Dispose();
    }
