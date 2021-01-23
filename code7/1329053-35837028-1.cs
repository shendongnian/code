    protected void Page_Load(object sender, EventArgs e)
            {
                // Create a timer
                System.Timers.Timer myTimer = new System.Timers.Timer();
              //call method
                myTimer.Elapsed += new ElapsedEventHandler(mymethod);
              //time interval 5 sec
                myTimer.Interval = 5000;
                myTimer.Enabled = true;
            }
    public void mymethod(object source, ElapsedEventArgs e)
            {            
                //your code
            }
