    private void button1_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                CheckForIllegalCrossThreadCalls = false;
                for (int i = 1; i < 5; i++)
                {
                    label1.Text = "Downloading " + i + " out of 4 files";
                    Thread.Sleep(2000);
                }
                label1.Text = "Downloading Completed!";
            }).Start();
        }
