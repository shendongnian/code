    DateTime endTime;
    private void MainForm_Load(object sender, EventArgs e)
    {
        ShowPasswordForm();
    }
    private void ShowPasswordForm()
    {
        timer1.Stop();
        var f = new PasswordForm();
        var passed = false;
        while (!passed)
        {
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                passed = true;
        }
        var startTime = DateTime.Now;
        endTime = startTime.AddMinutes(1); //I used 1 minute for test, add the time you need.
        timer1.Interval = 1000;
        timer1.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        var diff = endTime.Subtract(DateTime.Now);
        this.Text = string.Format("Remaining: {0} d {1:D2}:{2:D2}:{3:D2}",
                                diff.Days, diff.Hours, diff.Minutes, diff.Seconds);
        if (DateTime.Now >= endTime)
        {
            timer1.Stop();
            this.Text = "Remaining: 0 d 00:00:00";
            MessageBox.Show("Time is over.");
            ShowPasswordForm();
        }
    }
