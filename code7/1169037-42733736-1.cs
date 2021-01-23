    // change overlays
    private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBox combobox = sender as ComboBox;
        if (combobox != null && MainMap != null)
        {
            // show all overlays
            if (combobox.SelectedIndex == combobox.Items.Count - 1)
            {
                foreach (GMapMarker marker in MainMap.Markers)
                    marker.Shape.Visibility = Visibility.Visible;
            }
            // show only selected overlay
            else
            {
                foreach (GMapMarker marker in MainMap.Markers)
                {
                    if (marker.ZIndex == combobox.SelectedIndex)
                        marker.Shape.Visibility = Visibility.Visible;
                    else
                        marker.Shape.Visibility = Visibility.Collapsed;
                }
            }
            currentMarker.Shape.Visibility = Visibility.Visible;
        }
    }
