    private void Form1_Load(object sender, EventArgs e)
    {
        picturebox1.visible = true;
        Timer MyTimer = new Timer();
        MyTimer.Interval = (1000);
        MyTimer.Tick += new EventHandler(MyTimer_Tick);
        MyTimer.Start();
    }
    private void MyTimer_Tick(object sender, EventArgs e)
    {
        picturebox1.visible = false;
    }
