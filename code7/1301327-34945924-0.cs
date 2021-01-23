    public void RefreshListbox()
    {
        var slideDataItems = new ObservableCollection<ITimeLineDataItem>();
    
        foreach (podiaPublish.Marker pMarker in Global.gChapter.MarkerList)
        {
            if (pContent.Markup.Contains(".png"))
            {
                 var brush = new ImageBrush(bitmapSource);
    
                 var lb1 = new TempDataType()
                 {
                     Name = pContent.Markup,
                     BackgroundImage = brush
                 };
    
                 slideDataItems.Add(lb1);
             }
        }
        SlideDataItems = slideDataItems;
    }
