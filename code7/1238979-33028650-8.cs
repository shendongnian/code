    //When click on notify icon, we bring the form to front
    private void notifyIcon_Click(object sender, EventArgs e)
    {
        this.ShowInTaskbar = true;
        this.WindowState = FormWindowState.Minimized;
        this.Show();
        this.WindowState = FormWindowState.Normal;
    }
    //here we check if the user minimized window, we hide the form
    private void ApplicationMainForm_Resize(object sender, EventArgs e)
    {
        if (this.WindowState == FormWindowState.Minimized)
        {
            this.ShowInTaskbar = false;
            this.Hide();
        }
    }
    //when the form is hidden, we show notify icon and when the form is visible we hide it
    private void ApplicationMainForm_VisibleChanged(object sender, EventArgs e)
    {
        this.notifyIcon1.Visible = !this.Visible;
    }
