    public class PreviewItem
    {
       public string ItemName { get; set; }
       public Point PreviewStartingPoint { get; set; }
       public Point ReleaseStartingPoint { get; set; }
       public double PreviewWidth { get; set; }
       public double PreviewHeight { get; set; }
       public double ReleaseWidth { get; set; }
       public double ReleaseHeight { get; set; }
       public Border PreviewBorder { get; set; }
       public DispatcherTimer ShowTimer { get; private set; }   //  <-- private set
       public int ShowIndex { get; set; }
       public List<MarketingItemNode> HandleList { get; set; }
       public PreviewItem()
       {
           ShowTimer = new DispatcherTimer
           {
                Interval = TimeSpan.FromMilliseconds(previewItem.HandleList[0].Duration)
           };
           ShowTimer.Tick += ShowNextItem;
       }
       private void ShowNextItem(object sender, EventArgs eventArgs)
       {
            DispatcherTimer thisTimer = (DispatcherTimer) sender;
            PreviewItem thisItem = this;   // <-- for example, because you're in the object itself...
            ...
       }
    }
