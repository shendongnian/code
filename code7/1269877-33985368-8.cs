    System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
    int Step;
    Form1 () 
    {
         InitializeComponent()
        ....
         t.Interval = 15000; // specify interval time as you want
         t.Tick += new EventHandler(timer_Tick); 
         t.Start();
         this.Step = 2; 
    }
