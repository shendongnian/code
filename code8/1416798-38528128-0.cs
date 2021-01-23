    public class c1
    {
        private static iLock = new object();
        public void do1()
        {
            lock (iLock)
            {
              // actual method body
            }
        }
        public void do2()
        {
            lock (iLock)
            {
              // actual method body
            }
        }
    }
