                private void _timer_Elapsed(object sender, ElapsedEventArgs e)
                {
                Console.WriteLine("TimerElapsed thread id: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
                lock (_itemsLock)
                {    
                  System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,(Action)delegate()
                      {
                         Items.Add("Test");       
                      });
                }
            }
