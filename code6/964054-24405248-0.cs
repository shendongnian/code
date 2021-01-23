    if (!IsUploadingAvailable())
    {
        MessageBox.Show("Uploading is not available, please wait until it is ready!", "Upload not available");
        myButton.Enabled = false;
        await WaitForUploadingAvailable();
        MessageBox.Show("Uploading is now available!");
    }
    async Task WaitForUploadingAvailable()
    {
        await Task.Run(() =>
        {
            while (!IsUploadingAvailable())
            {
                Thread.Sleep(RandomAmountOfTime(10000));
            }
        });
    }
