        async void GetDownloadSpeedAsync(this Label lbl Uri address, int numberOfTests)
        {
            string directoryName = @"C:\Work\Test\speedTest";
            string fileName = "tmp.dat";
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < numberOfTests; ++i)
            {
                using (WebClient client = new WebClient())
                {
                    await client.DownloadFileAwaitableAsync(address, Path.Combine(directoryName, fileName), CancellationToken.None);
                }
            }
            lbl.Text == Convert.ToString(timer.Elapsed.TotalSeconds / numberOfTests);
        }
