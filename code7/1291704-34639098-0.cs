    bool blockClosing = true;
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        e.Cancel = blockClosing;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        blockClosing = false;
        Application.Exit();
    }
