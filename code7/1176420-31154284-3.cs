    private async void button1_Click(object sender, EventArgs e)   // add the async
    {
        for (int i = 0; i < 1000; i++)
        {
            label1.Text = "" + i;
            await Task.Delay(100);
        }
    }
