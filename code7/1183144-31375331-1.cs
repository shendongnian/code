    delegate void textChangeDelegate(int x);
        
    private void btnRun_Click(object sender, EventArgs e)
    {
        Thread thread = new Thread(new ThreadStart(new MethodInvoker(threadJob)));
        thread.IsBackground = true;
        thread.Start();
    }
    public void threadJob()
    {
        Invoke(new MethodInvoker(show));
        for (int i = 0; i < 10; i++)
        {
            Invoke(new textChangeDelegate(textChange),new object[]{i});
            Thread.Sleep(500);
        }
        Invoke(new MethodInvoker(hide));
    }
    public void textChange(int x)
    {
        if (InvokeRequired)
        {
            BeginInvoke(new textChangeDelegate(textChange),new object[] {x});
            return;
        }
        x += 1;
        lblText.Text = "Count: " + x;
    }
    public void show()
    {
        pgbRun.Visible = true;
        lblText.Visible = true;
    }
    public void hide()
    {
        pgbRun.Visible = false;
        lblText.Text = "";
        lblText.Visible = false;
    }
