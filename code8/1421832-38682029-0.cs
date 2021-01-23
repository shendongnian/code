      internal class MyThreadExample
      {
        private static int m_Count1;
        private static int m_Count2;
        private readonly object m_SyncObj = new object();
        private readonly Thread m_T1;
        private readonly Thread m_T2;
    
        public MyThreadExample()
        {
          m_T1 = new Thread(Increment) {IsBackground = true};
          m_T2 = new Thread(Checkequal) {IsBackground = true};
        }
    
        public static void Main()
        {
          var mt = new MyThreadExample();
          mt.m_T1.Start();
          mt.m_T2.Start();
          Console.Read();
        }
    
        private void Increment()
        {
          while (true)
          {
            lock (m_SyncObj)
            {
              m_Count1++;
              m_Count2++;
            }
            Thread.Sleep(1000); //stuck when use Sleep!
          }
        }
    
        private void Checkequal()
        {
          while (true)
          {
            lock (m_SyncObj)
            {
              Console.WriteLine(m_Count1 == m_Count2 ? "Synchronize" : "unSynchronize");
            }
            Thread.Sleep(1000);
          }
        }
      }
