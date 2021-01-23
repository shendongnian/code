    previewItem.ShowTimer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(previewItem.HandleList[0].Duration),
                    Tag = previewItem
                };
                previewItem.ShowTimer.Tick += ShowNextItem;
                previewItem.ShowTimer.Start();
 
    private void ShowNextItem(object sender, EventArgs eventArgs)
        {
            DispatcherTimer thisTimer = (DispatcherTimer) sender;
            PreviewItem thisItem = (PreviewItem) thisTimer.Tag;
            ...
        }
