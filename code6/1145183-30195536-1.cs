    void wc_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
    {
        WebClient wc=sender as WebClient;
          
        // Try to extract the filename from the Content-Disposition header
        if (!String.IsNullOrEmpty(wc.ResponseHeaders["Content-Disposition"]))
        {
            string[] values = wc.ResponseHeaders["Content-Disposition"].Split(';');
            string fileName = values.Single(v => v.Contains("filename"))
                                    .Replace("filename=","")
                                    .Replace("\"","");
            /**********  HERE IS THE PARAMETER   ********/
            string myParameter = values.Single(v => v.Contains("MyParameter"))
                                       .Replace("MyParameter=", "")
                                       .Replace("\"", "");
        }
        var data = e.Result; //File ok
    }
