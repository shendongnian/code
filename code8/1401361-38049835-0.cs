    private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
    
            if (txtSearch.Text != String.Empty)
            {
    
                GetTheListOfFiles();
                listView.Dispatcher.BeginInvoke(new Action(() => listView.Items.Clear()), DispatcherPriority.Background);
            }
        }
