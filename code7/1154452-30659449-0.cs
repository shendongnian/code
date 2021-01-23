    partial void Download_Execute()
        {
            int fileId = this.FileCollection.SelectedItem.Id;
            Uri hostUri = null;
            Dispatchers.Main.Invoke(() =>
            {
                hostUri = System.Windows.Application.Current.Host.Source;
                
            });
           
            Dispatchers.Main.Invoke(() =>
            {
                UriBuilder myUri = new UriBuilder(hostUri.Scheme, hostUri.Host, hostUri.Port, "Download.aspx",
                   "?Id=" + fileId);
                
                HtmlPage.Window.Navigate(myUri.Uri, "_new");
            });
     
        }
