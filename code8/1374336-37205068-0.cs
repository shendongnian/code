    private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                Application.DoEvents();
                label1.Text = i.ToString();
                Thread.Sleep(100);
            }
        }
