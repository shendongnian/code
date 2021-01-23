                RectLatLng area = mapView.SelectedArea;
            if (!area.IsEmpty)
            {
                for (int i = (int)mapView.Zoom; i <= mapView.MaxZoom; i++)
                {
                    TilePrefetcher obj = new TilePrefetcher();
                    obj.Title = "Prefetching Tiles";
                    obj.Icon = this.Icon;
                    obj.Owner = this;
                    obj.ShowCompleteMessage = false;
                    obj.Start(area, i, mapView.MapProvider, 100);
                }
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("No Area Chosen", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
