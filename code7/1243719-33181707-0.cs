        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Log.Entries.CollectionChanged += Entries_CollectionChanged;
            this.LogItemsControl.ItemsSource = Log.Entries;
            lastExtentHeight = this.ScrollViewer.ExtentHeight;
        }
        private void Entries_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            lastExtentHeight = this.ScrollViewer.ExtentHeight;
            if (scrollingPaused)
            {
                double sizeGrown = ScrollViewer.ExtentHeight - pausedExtentHeight;
                pausedVerticalOffset += sizeGrown;
                pausedExtentHeight = ScrollViewer.ExtentHeight;
                this.ScrollViewer.ChangeView(0, pausedVerticalOffset, 1, true);
            }
        }
        private void PlayPauseAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (scrollingPaused)
            {
                // UnPause
                scrollingPaused = false;
            }
            else
            {
                // Play
                pausedVerticalOffset = this.ScrollViewer.VerticalOffset;
                pausedExtentHeight = lastExtentHeight;
                scrollingPaused = true;
            }
        }
