    private async void waitForTasks()
    {
        while (ImagePropertiesTasks.Count > 0)
        {
            Task<ImagePropertyUpdater> task = await Task.WhenAny(ImagePropertiesTasks);
            ImagePropertiesTasks.Remove(task);
            ImagePropertyUpdater updater = await task;
            updater.UpdateImageRecord();
            if (ImagePropertiesQueue.Count > 0)
            {
                ImagePropertyQueueArgs args = ImagePropertiesQueue.Dequeue();
                ImagePropertiesTasks.Add(processImageAsync(args));
                ActiveTasks++;
            }
        }
    }
