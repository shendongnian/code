    private void Form1_Load(object sender, EventArgs e)
    {
        this.userControl11.StatusUpdate += userControl11_StatusUpdate;
    }
    void userControl11_StatusUpdate(object sender, MouseEventArgs e)
    {
        this.toolStripStatusLabel1.Text = e.Location.ToString();
    }
