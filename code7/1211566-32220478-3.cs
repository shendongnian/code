    public class A
    {
        private static readonly object _sync = new object();
    
        public void DoStuff() 
        {
              // All threads trying to enter this critical section will
              // wait until the first to enter exits it
              lock(_sync)
              {
                  byte[] buffer = File.ReadAllBytes(@"C:\file.jpg");
              }
        }
    }
