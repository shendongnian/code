    public Form1()
    {
        InitializeComponent();
        thProgram = new Thread(new ThreadStart(this.Run));
    }
    private bool Running = false;
	private AutoResetEvent ThreadHandle = new AutoResetEvent(false);
    public void Run()
    {
        int i = 0;
        while(true)
        {
			ThreadHandle.WaitOne();
            i++;
        }
        MessageBox.Show("Terminated");
    }
     // handling bot activation button (changing color of a pictureBox1), switching this.Running property
    private void button1_Click(object sender, EventArgs e)
    {
        if(this.Running)
        {
            thProgram.Abort();
            pictureBox1.BackColor = Color.Red;
            this.ThreadHandle.Reset();
			this.Running = false;
        }
        else
        {
            thProgram.Start();
            pictureBox1.BackColor = Color.Lime;
            this.ThreadHandle.Set();
			this.Running = true;
        }
    }
