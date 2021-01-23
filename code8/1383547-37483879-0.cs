        private void WaitOrTimerCallback(object state, bool timedOut) {
            long ticks = DateTime.Now.Ticks;
            if (timedOut) {
                Console.WriteLine(string.Format("Timeout : {0} ... Do scheduled job takes 1 seconds long, Thread ID : {1}", (ticks - m_LastTicks) / 10000f, Thread.CurrentThread.ManagedThreadId));
                ThreadPool.RegisterWaitForSingleObject(Event, new WaitOrTimerCallback(WaitOrTimerCallback), null, 500, true);
            }
            else {
                Console.WriteLine(string.Format("Signaled....Unregister , Thread ID : {0}", Thread.CurrentThread.ManagedThreadId));
                m_RegisterWaitHandle.Unregister(null);
            }
            m_LastTicks = ticks;
        }
