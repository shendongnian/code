    private async void button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < 100; i++)
        {
            label1.Text = i.ToString();
            await Task.Run(() => { Thread.Sleep(100); });
        }
    }
