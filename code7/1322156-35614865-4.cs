    string status = string.Empty;
    Thread thread = new System.Threading.Thread(() =>
    {
        while(status != "Done")
            status = Download(downloadKit, patchTitle);
    });
    thread.Start();
    thread.Join();
    
    //do what needs to be done
