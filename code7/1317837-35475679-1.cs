      private void button1_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                CheckForIllegalCrossThreadCalls = false;
                while(CheckProgress() <= 4)
                {
                   label1.Text = "Downloading " + CheckProgress() + " out of 4 files"; 
                    
                }
                
                label1.Text = "Downloading Completed!";
            }).Start();
        }
