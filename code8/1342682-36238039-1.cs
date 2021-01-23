    private void SomeMethod()
    {
        Task.Run(() =>
        {
            while (true)
            {
                this.Dispatcher.Invoke(() =>
                {
                    double position = media.Position.TotalSeconds;
                    if (position >= Stop) // Stop position
                        media.Position = TimeSpan.FromSeconds(Start); // Start position
                });
                Thread.Sleep(100);
            }
        });
    }
