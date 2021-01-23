    // Declare a System.Threading.CancellationTokenSource.
            CancellationTokenSource cts;
    
            private async void startButton_Click(object sender, RoutedEventArgs e)
            {
                // Instantiate the CancellationTokenSource.
                cts = new CancellationTokenSource();    
                resultsTextBox.Clear();    
                try
                {
                    // ***Set up the CancellationTokenSource to cancel after 2.5 seconds. (You 
                    // can adjust the time.)
                    cts.CancelAfter(2500);    
                    await AccessTheWebAsync(cts.Token);
                    resultsTextBox.Text += "\r\nDownloads succeeded.\r\n";
                }
                catch (OperationCanceledException)
                {
                    resultsTextBox.Text += "\r\nDownloads canceled.\r\n";
                }
                catch (Exception)
                {
                    resultsTextBox.Text += "\r\nDownloads failed.\r\n";
                }    
                cts = null; 
            }    
    
            // You can still include a Cancel button if you want to. 
            private void cancelButton_Click(object sender, RoutedEventArgs e)
            {
                if (cts != null)
                {
                    cts.Cancel();
                }
            }    
    
            async Task AccessTheWebAsync(CancellationToken ct)
            {
                // Declare an HttpClient object.
                HttpClient client = new HttpClient();    
                // Make a list of web addresses.
                List<string> urlList = SetUpURLList();    
                foreach (var url in urlList)
                {
                    // GetAsync returns a Task<HttpResponseMessage>.  
                    // Argument ct carries the message if the Cancel button is chosen.  
                    // Note that the Cancel button cancels all remaining downloads.
                    HttpResponseMessage response = await client.GetAsync(url, ct);    
                    // Retrieve the website contents from the HttpResponseMessage. 
                    byte[] urlContents = await response.Content.ReadAsByteArrayAsync();    
                    resultsTextBox.Text +=
                        String.Format("\r\nLength of the downloaded string: {0}.\r\n"
                       , urlContents.Length);
                }
            }
