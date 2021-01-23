    // Add a using directive and a reference for System.Net.Http. 
    using System.Net.Http;
    
    // Add the following using directive. 
    using System.Threading;
    
    
    namespace ProcessTasksAsTheyFinish
    {
        public partial class MainWindow : Window
        {
            // Declare a System.Threading.CancellationTokenSource.
            CancellationTokenSource cts;
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private async void startButton_Click(object sender, RoutedEventArgs e)
            {
                resultsTextBox.Clear();
    
                // Instantiate the CancellationTokenSource.
                cts = new CancellationTokenSource();
    
                try
                {
                    await AccessTheWebAsync(cts.Token);
                    resultsTextBox.Text += "\r\nDownloads complete.";
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
    
    
            private void cancelButton_Click(object sender, RoutedEventArgs e)
            {
                if (cts != null)
                {
                    cts.Cancel();
                }
            }
    
    
            async Task AccessTheWebAsync(CancellationToken ct)
            {
                HttpClient client = new HttpClient();
    
                // Make a list of web addresses.
                List<string> urlList = SetUpURLList();
    
                // ***Create a query that, when executed, returns a collection of tasks.
                IEnumerable<Task<int>> downloadTasksQuery =
                    from url in urlList select ProcessURL(url, client, ct);
    
                // ***Use ToList to execute the query and start the tasks. 
                List<Task<int>> downloadTasks = downloadTasksQuery.ToList();
    
                // ***Add a loop to process the tasks one at a time until none remain. 
                while (downloadTasks.Count > 0)
                {
                        // Identify the first task that completes.
                        Task<int> firstFinishedTask = await Task.WhenAny(downloadTasks);
    
                        // ***Remove the selected task from the list so that you don't 
                        // process it more than once.
                        downloadTasks.Remove(firstFinishedTask);
    
                        // Await the completed task. 
                        int length = await firstFinishedTask;
                        resultsTextBox.Text += String.Format("\r\nLength of the download:  {0}", length);
                }
            }
    
    
            private List<string> SetUpURLList()
            {
                List<string> urls = new List<string> 
                { 
                    "http://msdn.microsoft.com",
                    "http://msdn.microsoft.com/library/windows/apps/br211380.aspx",
                    "http://msdn.microsoft.com/en-us/library/hh290136.aspx",
                    "http://msdn.microsoft.com/en-us/library/dd470362.aspx",
                    "http://msdn.microsoft.com/en-us/library/aa578028.aspx",
                    "http://msdn.microsoft.com/en-us/library/ms404677.aspx",
                    "http://msdn.microsoft.com/en-us/library/ff730837.aspx"
                };
                return urls;
            }
    
    
            async Task<int> ProcessURL(string url, HttpClient client, CancellationToken ct)
            {
                // GetAsync returns a Task<HttpResponseMessage>. 
                HttpResponseMessage response = await client.GetAsync(url, ct);
    
                // Retrieve the website contents from the HttpResponseMessage. 
                byte[] urlContents = await response.Content.ReadAsByteArrayAsync();
    
                return urlContents.Length;
            }
        }
    }
