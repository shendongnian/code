       public void bgWorker_DoWork(object sender, DoWorkEventArgs e)
       {
            // action to string format
            string action = e.Argument as string;
            if (action == "dr_begin_dd_check")
            {
                        BeginInvoke((Action)(() =>
                        {
                            statusLabel.Text = "Access the bgw...";
                        }
                        ));
            } // dr_begin_dd_check
