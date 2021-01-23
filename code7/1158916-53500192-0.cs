     public Task<string> DownloadFile(Uri url)
            {
                var tcs = new TaskCompletionSource<string>();
                Task.Run(async () =>
                {
                    bool hasProgresChanged = false;
                    var timer = new Timer(new TimeSpan(0, 0, 20).TotalMilliseconds);
                    var client = new WebClient();
    
                    void downloadHandler(object s, DownloadProgressChangedEventArgs e) => hasProgresChanged = true;
                    void timerHandler(object s, ElapsedEventArgs e)
                    {
                        timer.Stop();
                        if (hasProgresChanged)
                        {
                            timer.Start();
                            hasProgresChanged = false;
                        }
                        else
                        {
                            CleanResources();
                            tcs.TrySetException(new TimeoutException("Download timedout"));
                        }
                    }
                    void CleanResources()
                    {
                        client.DownloadProgressChanged -= downloadHandler;
                        client.Dispose();
                        timer.Elapsed -= timerHandler;
                        timer.Dispose();
                    }
    
                    string filePath = Path.Combine(Path.GetTempPath(), Path.GetFileName(url.ToString()));
                    try
                    {
                        client.DownloadProgressChanged += downloadHandler;
                        timer.Elapsed += timerHandler;
                        timer.Start();
                        await client.DownloadFileTaskAsync(url, filePath);
                    }
                    catch (Exception e)
                    {
                        tcs.TrySetException(e);
                    }
                    finally
                    {
                        CleanResources();
                    }
    
                    return tcs.TrySetResult(filePath);
                });
    
                return tcs.Task;
            }
