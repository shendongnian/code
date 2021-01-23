    protected void Page_Load(object sender, EventArgs e)
    {         
         System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer();
         tm.Tick += tm_Tick;
         tm.Interval = 1000;
         tm.Start();
    }
    
    void tm_Tick(object sender, EventArgs e)
    {
         int lbl = Convert.ToInt32(label1.Text);
         label1.Text = (lbl + 1).ToString();
    }
