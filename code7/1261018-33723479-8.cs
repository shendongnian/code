    using (WebClient wc = new WebClient()) {
        object waitObject = new object();
        lock (waitObject)
        {
            wc.DownloadFileCompleted += (sender, e) =>
            {
                lock (waitObject) Monitor.Pulse(waitObject);
            };
            wc.DownloadFileAsync(urlUri, outputFile);
            SomeMethod1();
            SomeMethod2();
            Monitor.Wait(waitObject);
        }
    }
