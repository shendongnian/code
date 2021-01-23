    private void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        Task.Run(() =>
        {
            // ... do something here
            Invoke((Action)(() => button1.Enabled = true)); // enable button again
        });
    }
