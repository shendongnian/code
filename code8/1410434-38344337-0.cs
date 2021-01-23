    class Form1 : Form
    {
           Timer timer;
    	  
    	   public Form1()
           {
    	        InitializeComponent();
                timer = new Timer();
                timer.Interval = 500;
                timer.Tick += new EventHandler(Timer_Tick);
    	   }
           private void App_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Clicks == 1)
                {
                    timer.Start();
                }
                else
                {
                    timer.Stop();
                    doubleClick();
                }
            }
    		
    		private void Timer_Tick(object sender, EventArgs e)
            {
                timer.Stop();
                singleClick();
            }
    		
    		//Single click 
            public void singleClick()
            {
               MessageBox.Show("Single Click.");
            }
    
            //Double click 
            public void doubleClick()
            {
               MessageBox.Show("Double Click.");
            }
    }
