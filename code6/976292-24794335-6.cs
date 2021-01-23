    private volatile int activeProcessCount = 0;
    private void pro_Exited(object sender, EventArgs e)
    {
        activeProcessCount--;
        if (activeProcessCount == 0)
        {
            button1.Invoke((MethodInvoker) delegate { button1.Enabled = true; });
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        //code
        activeProcessCount = 2;
        pro1.Start();
        pro2.Start();
    }
