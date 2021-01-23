        private async void StartButton_Click_1(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                Ping ping = new Ping();
                ContinuePing = true;
                do
                {
                    try ///ping google
                    {
                        PingReply reply = ping.Send("8.8.8.8");
                        if (reply.Status == IPStatus.Success)
                        {
                            SetLabelColor(GoogleStatusLabel.BackColor, Color.Green);
                        }
                    }
                    catch
                    {
                        SetLabelColor(GoogleStatusLabel.BackColor, Color.Red);
                    }
                    try ///ping Yahoo!
                    {
                        PingReply reply = ping.Send("www.yahoo.com");
                        if (reply.Status == IPStatus.Success)
                        {
                            SetLabelColor(YahooStatusLabel.BackColor, Color.Green);
                        }
                    }
                    catch
                    {
                        SetLabelColor(YahooStatusLabel.BackColor, Color.Red);
                    }
                    try ///ping Reddit.com
                    {
                        PingReply reply = ping.Send("www.reddit.com");
                        if (reply.Status == IPStatus.Success)
                        {
                            SetLabelColor(RedditStatusLabel.BackColor, Color.Green);
                        }
                    }
                    catch
                    {
                        SetLabelColor(RedditStatusLabel.BackColor, Color.Red);
                    }
                    try ///ping Chive
                    {
                        PingReply reply = ping.Send("www.chive.com");
                        if (reply.Status == IPStatus.Success)
                        {
                            SetLabelColor(ChiveStatusLabel.BackColor, Color.Green);
                        }
                    }
                    catch
                    {
                        SetLabelColor(ChiveStatusLabel, Color.Red);
                    }
                    try ///ping CNN
                    {
                        PingReply reply = ping.Send("www.cnn.com");
                        if (reply.Status == IPStatus.Success)
                        {
                            SetLabelColor(CNNStatusLabel, Color.Green);
                        }
                    }
                    catch
                    {
                        SetLabelColor(CNNStatusLabel, Color.Red);
                    }
                } while (ContinuePing);
            });
        }
        private void SetLabelColor(Label lbl, Color clr)
        {
            this.Invoke((MethodInvoker)delegate {
                lbl.BackColor = clr;
            });
        }
