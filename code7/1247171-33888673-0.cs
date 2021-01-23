    private async void tapROIGrid_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        if (media capture not initialized || focus not supported || roi auto focus not supported)
            return;
            
            
        VideoEncodingProperties properties = MediaCapture.VideoDeviceController.GetMediaStreamProperties(MediaStreamType.VideoPreview) as VideoEncodingProperties;
        uint CurrentViewFinderResWidth = properties.Width;
        uint CurrentViewFinderResHeight = properties.Height;
    
        _vfResToScreenFactor = ((double)CurrentViewFinderResHeight) / _tapROIGrid.ActualHeight;
        var pos = e.GetPosition(sender as UIElement);
        var point1 = new Point( (pos.X - 25) * _vfResToScreenFactor, (pos.Y - 25) * _vfResToScreenFactor);
        if (point1.X < 0)
            point1.X = 0;
        if (point1.Y < 0)
            point1.Y = 0;
    
        var point2 = new Point((pos.X + 25) * _vfResToScreenFactor, (pos.Y + 25) * _vfResToScreenFactor);
        if (point2.X > ((double)CurrentViewFinderResWidth))
            point2.X = ((double)CurrentViewFinderResWidth);
        if (point2.Y > ((double)CurrentViewFinderResHeight))
            point2.Y = ((double)CurrentViewFinderResHeight);
    
        var region = new RegionOfInterest();
        region.Bounds = new Rect(point1, point2);
        region.BoundsNormalized = false;
        region.AutoFocusEnabled = true;
        region.AutoExposureEnabled = true; //this will make exposure for roi
        region.AutoWhiteBalanceEnabled = true; //this will make wb for roi
        var List<RegionOfInterest> RoiRegions new List<RegionOfInterest>(1);
        RoiRegions.Add(region);
        await _app.VM.MediaCapture.VideoDeviceController.RegionsOfInterestControl.ClearRegionsAsync();
        await _app.VM.MediaCapture.VideoDeviceController.RegionsOfInterestControl.SetRegionsAsync(RoiRegions, true);
    
        //note: before focusing, make sure or set single focus mode. That part of code not here.
        await FocusAsync();
    }
