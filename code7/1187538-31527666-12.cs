        public class WaitForSeconds: ICommandExecutor, IDisposable
        {
            int ms;
            System.Threading.Timer timer;
            ManualResetEvent timerDone = new ManualResetEvent(false);
            public WaitForSeconds(int secs)
            {
                this.ms = secs * 1000;
            }
            public void Execute()
            {
                // use a timer
                timer = new System.Threading.Timer(
                   (state) => timerDone.Set() // signal we are done
                   );
                timerDone.Reset();
                timer.Change(this.ms, Timeout.Infinite);
            }
            public void Dispose()
            {
                timerDone.WaitOne();
                timerDone.Dispose();
                timer.Dispose();
            }
        }
