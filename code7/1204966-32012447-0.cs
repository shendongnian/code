     private void button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < 10; i++)
        {
            label9.Text = "Processing " + i.ToString();
            Thread.Sleep(1000);
            Form1.Refresh();
        }
    }
