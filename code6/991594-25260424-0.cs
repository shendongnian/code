    private void DownloadStringCallback2(Object sender, DownloadStringCompletedEventArgs e)
        {
            var indicator = SystemTray.GetProgressIndicator(this);
            indicator.IsIndeterminate = false;
            indicator.Text = "";
            if (!e.Cancelled && e.Error == null)
            {
                MessageBox.Show("Page load complete.");
                
                //Do whatever with the downloaded string (e.Result)
            }
        }  
