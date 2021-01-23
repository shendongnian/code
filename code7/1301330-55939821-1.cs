    public void RefreshListbox()
    {
        SlideDataItems.Clear();
    
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
    
                 _slideDataItems.Add(lb1);
             }
        }
    }
