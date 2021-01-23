        private readonly Mutex m = new Mutex();
        public void ThreadSafeMethod() {
            m.WaitOne();
            try {
                /*excel related critical code */
            } finally {
                m.ReleaseMutex();
            }
        }
<!-- -->
