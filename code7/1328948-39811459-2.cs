    //Calling asynch method, running on the same thread,
    //doing the work as it is eligible for doing.;
    Task<string> x = new WebClient().DownloadStringTaskAsync("http://stackoverflow.com");
    Console.WriteLine("I'm writing something while the task is running...");
    Console.WriteLine("Content of webpage is: {0}", await x);
