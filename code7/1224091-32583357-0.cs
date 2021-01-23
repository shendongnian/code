       private void btnStart_Click(object sender, EventArgs e)
       {
            if (timer.Enabled)
            {
                timer.Stop();
                btnStart.Text = "START";
                lbTime.Items.Add("Time:" + lbCounter.Text);
                counter = 0;
                lbCounter.Text = "";
            }
            else
            {
                timer.Start();
                btnStart.Text = "STOP";
            }
        }
