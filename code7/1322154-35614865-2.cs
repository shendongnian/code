    string status = string.Empty;
    Thread thread = new System.Threading.Thread(() =>
    {
        while(status != "Done")
            status = Download(downloadKit, patchTitle);
    });
    thread.Start();
    thread.Join();
    
    //no point in looping here, if the thread finished, it has already assigned the
    //value it is going to assign to the status variable
    if (status == "Done")
    {
        //do what needs to be done
    }
    else
    {
       //uh oh, handle the failure here
    }
