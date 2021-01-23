    if (timer.Enabled)
               {
                    timer.Stop();
                    btnStart.Text = "START";
                    lbTime.Items.Add("Time:" + lbCounter.Text);
                    lbCounter.Text = "";
                }
                else
                {
                    counter = 0; // Added code.
                    timer.Start();
                    btnStart.Text = "STOP";
                }
