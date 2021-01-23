        result = "";
        Task.Run(() =>
        {
            foreach (string path in paths)
            {
                result = File.ReadAllBytes(path);
            }
        }.ContinueWith(x =>
        {
            result = result.remove(25);
        }, TaskScheduler.FromCurrentSynchronizationContext());
