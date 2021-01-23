    public int ZoomLevel {get; set;} = initialZoomLevel;
    
    private void OnZoomLevelChanged(object sender, EventArgs args)
    {
        if((int)Map.ZoomLevel!=ZoomLevel)
        {
            //Rerender stuff
        }
    }
