    public static int interval {get;set;}
    public bool? done = null;    // set to false when app first loads
    protected override void OnStart(string[] args) {
        if(done == null){
            timer1.Elapsed += new ElapsedEventHandler(timer1_Elapsed);
            timer1.Interval = 43200000; //execute for every 12 hours
            timer1.Enabled = true;
            timer1.Start();
        }
    }
    private void timer1_Elapsed(object sender, EventArgs e) {
        Library.WriteErrorLog("Timer is called .......................");
        if((done == null) || (done == true)) 
        {   
            done = false;
            CheckprocessFile();
            done = true;
        }
        else
        {
            done = false;
            interval = 3600000; 
            timer1.Stop();
            timer1.Interval = interval;
            timer1.Enabled = true;
            timer1.Start();
        }
        
 
    }
    protected override void OnStop() {
        timer1.Enabled = false;
    } 
