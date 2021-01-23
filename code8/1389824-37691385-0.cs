        private void backgroundWorker1_ProgressChanged(object sender,
                                                       ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {                
                this.Invoke((MethodInvoker)delegate {
                          listBox1.Items.Add(e.UserState.ToString()); 
                      });
            }
        }
