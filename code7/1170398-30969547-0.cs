    public async void Run(IBackgroundTaskInstance taskInstance)
    {
        BackgroundTaskDeferral _deferral = taskInstance.GetDeferral();
        
        Debug.WriteLine("Test");
            Debug.WriteLine(DateTime.Now.ToString("g"));
    
            StorageFolder dataFolder = ApplicationData.Current.LocalFolder;
            StorageFile logFile = await dataFolder.CreateFileAsync("logFile.txt", CreationCollisionOption.OpenIfExists);
    
            IList<string> logLines = await FileIO.ReadLinesAsync(logFile);
    
            foreach( var s in logLines )
            {
                Debug.WriteLine(s);
            }
    
            logLines.Add(DateTime.Now.ToString("g"));
            if( logLines.Count > 5 )
            {
                logLines.RemoveAt(0);
            }
    
            await FileIO.AppendLinesAsync(logFile, logLines);
    
        _deferral.Complete(); 
    }
