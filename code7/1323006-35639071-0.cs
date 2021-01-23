    using System.Threading;
    using System.Windows.Forms;
    
    namespace ConsoleThreadSync
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                Application.Run(new App());
            }
        }
    
        public class App : ApplicationContext
        {
            private readonly SynchronizationContext _sync;
    
            public App()
            {
                var dummy = new Control(); // to initialize SynchronizationContext
                _sync = SynchronizationContext.Current;
                new Thread(ThreadProc).Start();
            }
    
            public void ShowFormFromAnotherThread(string text)
            {
                _sync.Post(SendOrPostCallback, text);
            }
    
            private void SendOrPostCallback(object state)
            {
                var form = new Form1();
                form.Text = (string)state;
                form.Show();
            }
    
            private void ThreadProc()
            {
                while (true)
                {
                    Thread.Sleep(2000); // wait imitation
                    ShowFormFromAnotherThread("HI");
                }
            }
        }
    }
