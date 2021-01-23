    private void timer1_Tick(object sender, EventArgs e)
        {           
            tagLASTINPUTINFO LastInput = new tagLASTINPUTINFO();
            Int32 IdleTime;
            LastInput.cbSize = (uint)Marshal.SizeOf(LastInput);
            LastInput.dwTime = 0;
            if (GetLastInputInfo(ref LastInput))
            {
                IdleTime = System.Environment.TickCount - LastInput.dwTime;
                if (IdleTime > 10000)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.pause();
                    timer1.Stop();
                    string timeRemaining = IdleTime.ToString();
                    lbl_TimeRemaining.Text = IdleTime.ToString();
                    lbl_TimeRemaining.Show();
                    MessageBox.Show("Do you wish to continue?");
                    lbl_TimeRemaining.Hide();
                }
                else
                {
                }
                timer1.Start();
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }            
            string title = axWindowsMediaPlayer1.currentMedia.getItemInfo("Title");
        }
