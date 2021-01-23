        private void backgroundWorker1_ProgressChanged(object sender,
                                                       ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                listBox1.Items.Add(e.UserState.ToString());                    
            }
        }
