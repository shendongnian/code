    var timer = Timer(5000);
    timer.Elapsed += (s, a) =>
    {
        // checking if file is still there
        if(File.Exists(...)
        {
            // do something
        }
    }
    timer.Start();
    
