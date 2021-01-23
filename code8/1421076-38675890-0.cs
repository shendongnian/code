       public partial class Service1 : ServiceBase
        {
            
            private Timer timer1 = null;
            private long isTaskRunning = 0;
    
            public Service1()
            {
                InitializeComponent();
            }
        
            protected override void OnStart(string[] args)
            {
                timer1 = new Timer();
                this.timer1.Interval = 20000;
                this.timer1.Elapsed += new  System.Timers.ElapsedEventHandler(this.timer1_Tick);
                timer1.Enabled = true;
                Library.WriteErrorLog("service has started");
            }
        
            private void timer1_Tick(object sender, ElapsedEventArgs e)
            {
                try
                {
               
                if (Interlocked.CompareExchange(ref isTaskRunning, 1, 0)==1)
                {
                 return;
                }
    
                //retrieve data from database
                //read rows
        
                //Loop through rows
                //send values through network
                //receive response and update db
                }
                catch (Exception ex)
                {
                    Library.WriteErrorLog(ex);
                }
                finally
                {
                 Interlocked.Exchange(ref isTaskRunning, 0);
                }
            }
        }
        
            protected override void OnStop()
            {
                timer1.Enabled = false;
                Library.WriteErrorLog("service has stopped");
            }
        }
