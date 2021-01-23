    using (WebClient wc = new WebClient()) {
        Task task = wc.DownloadFileAsync(urlUri, outputFile);
        SomeMethod1();
        SomeMethod2();
        await task;
    }
