    private async void OnButton1_Clicked(object sender, ...)
    {
        // prevent pressing the button while the files are being copied:
        this.button1.Enabled = false;
        // start copying files and wait until ready
        // Because this function is async, the UI remains responsive
        await this.CopyFiles();
        this.button1.Enabled = true;
    }
    // return Task instead of void!
    private async Task CopyFiles()
    {
        List<Task> runningTasks = new List<Task>();
        foreach (string myFileName in this.GetFilenameList()) 
        {
            runningTasks.Add(CopyDocumentAsync(myFileName));
        }
        // now that all tasks are running do other things you want to do,
        // wait for all Tasks to finish:
        await Task.WhenAll(runningTasks);
        // now that all tasks are finished you can return
    }
 
