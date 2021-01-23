    private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                label9.Text = "Processing " + i.ToString();
                Application.DoEvents();
                Thread.Sleep(1000);
            }
        }
