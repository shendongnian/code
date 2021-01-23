	         	System.Net.WebClient client = new System.Net.WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                client.OpenRead("http://example.com/thewebpage.aspx");
                Int64 bytes_total = Convert.ToInt64(client.ResponseHeaders["Content-Length"]);
                timerisat = bytes_total;
                if (timerisat > timerwas) // checks for change.
                {
                    pictureBox1.BackColor = Color.DarkRed; // changes color to green.
                    button7.FlatAppearance.BorderColor = Color.Red;
                    timerwas = timerisat + 20; // sets new value to check. (adds 20 bytes)         
                    // Notification pops up on tooltip.
                    this.notifyIcon1.BalloonTipText = "MyTSC Bulletin Board - Updated";
                    this.notifyIcon1.BalloonTipTitle = "Workspace";
                    this.notifyIcon1.Visible = true;
                    this.notifyIcon1.ShowBalloonTip(10);
                }
