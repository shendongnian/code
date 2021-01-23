    private static void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            // Displays the operation identifier, and the transfer progress.
            Console.WriteLine("{0}    downloaded {1} of {2} bytes. {3} % complete...",
                ((TaskCompletionSource<object>)e.UserState).Task.AsyncState,
                e.BytesReceived,
                e.TotalBytesToReceive,
                e.ProgressPercentage);
        }
    	
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            Uri uri = new Uri("http://download.thinkbroadband.com/100MB.zip");
    
            // Specify a progress notification handler.
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
            var task = client.DownloadFileTaskAsync(uri, "serverdata.txt"); // use Task based API
    		
    		task.Wait(); // Wait for download to complete, can deadlock in GUI apps
    		
            Console.WriteLine("Download complete");
    		
            Console.WriteLine("Download successful.");
        }
