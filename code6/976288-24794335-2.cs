    private void button1_Click(object sender, EventArgs e)
    {
        Process pro = new Process();
        pro.StartInfo.FileName = "notepad";
        pro.StartInfo.Arguments = "";
        pro.Start();
        button1.Enabled = false;
        pro.EnableRaisingEvents = true;
        pro.Exited += pro_Exited;
    }
    void pro_Exited(object sender, EventArgs e)
    {
         button1.Invoke((MethodInvoker) delegate { button1.Enabled = true; });
    }
