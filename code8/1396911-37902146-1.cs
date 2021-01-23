    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Net;
    using System.Threading.Tasks;
    namespace SO3
    {
        public class SODownloader
        {
            WebClient webClient;
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>(); //<-----
            public Task DownloadFile(String URL, String Path, String Name)
            {
            
                using (webClient = new WebClient())
                {
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    Uri Link = new System.Uri(URL);
                    try
                    {
                        Debug.WriteLine("Attempting to download: " + Name);
                        webClient.DownloadFileAsync(Link, Path);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
                return tcs.Task; //<-----
            }
            private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {
                Debug.WriteLine(e.ProgressPercentage.ToString() + "%");
            }
            private void Completed(object sender, AsyncCompletedEventArgs e)
            {
            
                if (e.Cancelled == true)
                {
                    tcs.TrySetException(new TaskCanceledException("Download has been canceled.")); //<-----
                    Debug.WriteLine("Download has been canceled.");
                }
                else
                {
                    tcs.TrySetResult("Download completed!"); //<-----
                    Debug.WriteLine("Download completed!");
                }
            }
        }
    }
    
