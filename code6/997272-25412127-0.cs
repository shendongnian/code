    private async void button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < 100; i++)
        {
            textBox1.Text = i.ToString();
            await Task.Delay(1000);
        }
        textBox1.Text = "Completed";
    }
