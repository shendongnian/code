    // add marker
    private void addMarker_Click(object sender, RoutedEventArgs e)
    {
        GMapMarker marker = new GMapMarker(currentMarker.Position);
        {
            ... // ToolTipText fetching logic
    
            marker.Shape = new CustomMarkerDemo(this, marker, ToolTipText);
            marker.ZIndex = combobox.SelectedIndex;
        }
        MainMap.Markers.Add(marker);
    }
