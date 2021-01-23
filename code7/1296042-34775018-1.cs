    public void GenerateImageAsync(Area area)
        {
            new Thread(() => {
                ready.Reset();
                GenerateImage(area);
                ready.Set();
            }).Start();
        }
