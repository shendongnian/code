    List<object> items = GetItemsToProcess();
    int doneSoFar = 0;
    foreach (var item in items)
    {
        await Task.Run(() => SomeCpuIntensiveWorkAsync(item));
        doneSoFar++;
        int progressPercentage = (int)((double)doneSoFar / items.Count * 100);
        // Update the UI.
        this.ProgressBar.Value = progressPercentage;
    }
