    async private void button1_Click(object sender, EventArgs e)
    {
        // change visibility here...
        this.label1.Visible = true;
        // this work will happen on separate thread,
        // so the UI thread will be free to update the label visibility
        await Task.Run(() => WorkToBePerformedOnSeparateThread());
        this.label1.Visible = false;
    }
    private void WorkToBePerformedOnSeparateThread()
    {
        // Put the function code here.
    }
