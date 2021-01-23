    public Task ProcessVideo(string input, xxx output)
    {
        string arguments = "thumbnail " + input + " " + output.LocalPath;
        Process p = Process.Start(videoToolPath, arguments);
        var tcs = new TaskCompletionSource<object>();
        p.Exited += (o, e) => 
        {
            if(p.ExitCode == 0)
            {
                tcs.SetResult(null);
            }
            else
            {
                tcs.SetException(someException);
            }
            p.Dispose();
        }
        return tcs.Task;
    }
    
    //Then call it by 
    var listOfFilesToProcess = new List<string>(){ ... };
    await Task.WhenAll(listOfFilesToProcess.Select(file => ProcessVideo(file, output));
