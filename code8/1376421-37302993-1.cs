    private void OnMapItemsPropertyChanged(DependencyObject sender, DependencyProperty dp)
    {
    var mapItemsControls = sender as MapItemsControl;
                var mapItemsSource = mapItemsControls?.ItemsSource as ObservableCollection<PointOfNode>;
    
                if (mapItemsSource != null)
                {
                    this.MainMap.MapElements.Clear();
                    if (mapItemsSource.Count > 1)
                    {
                        for (var i = 0; i < mapItemsSource.Count - 1; i++)
                        {
                            this.LinePoints(mapItemsSource[i].Location, (mapItemsSource[i + 1]).Location);
                        }
                    }
                }
    }
