    public partial class Form1 : Form
    {
        CStopWatch sw = new CStopWatch();
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Enabled = true;
    
            lblTime.Text = sw.StartClock();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
    
        }
    
        private void timer_Tick(object sender, EventArgs e)
        {
        	UpdateElapsedTime();
        	
           if (lblTime.InvokeRequired) 
           {
            	lblTime.Invoke(new MethodInvoker(() => 
            	{ 
            		lblTime.Text = sw.ElapsedTime;
            	}));
           }
        }
    }
