    public void GenerateImageAsync(Area area)
        {
            Task.Run(() => {
                ready.Reset();
                GenerateImage(area);
                ready.Set();
            });
        }
