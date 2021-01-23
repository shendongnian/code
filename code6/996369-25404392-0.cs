    private void GoogleS_Click(object sender, EventArgs e)
            {
                try
                {
                    //MessageBox.Show(ConfigurationManager.AppSettings["Google"]);
                    string GoogleS = ConfigurationManager.AppSettings["Google"];
                    Process.Start(GoogleS);
                }
                catch (Exception GoogleErr)
                {
                    MessageBox.Show(GoogleErr.Message);
                }
            }
    
            private void GoogleS_MouseHover(object sender, EventArgs e)
            {
                System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                ToolTip1.SetToolTip(this.GoogleS, (ConfigurationManager.AppSettings["Google"]));
            }
