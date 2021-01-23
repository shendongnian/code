    private async Task Task1()
    {
        for (int i = 0; i < 100; i++)
        {
            await Task.Delay(100);
            textBox1.Text = i.ToString();
        }
    }
