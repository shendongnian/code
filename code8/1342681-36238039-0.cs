    // Set video end position, call this just once when you have opened the video
    private void SetEndPosition()
    {
        Task.Run(() =>
        {
            while (true)
            {
                this.Dispatcher.Invoke(() =>
                {
                    double position = media.Position.TotalSeconds;
                    if (position >= Stop)
                        SetStartPosition();
                });
                Thread.Sleep(100);
            }
        });
    }
    // Set video start position
    private void SetStartPosition()
    {
        media.Position = TimeSpan.FromSeconds(Start);
    }
