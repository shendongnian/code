    void columns_MouseDown(object sender, MouseButtonEventArgs e)  
    {         
        var cols = sender as ColumnSeries;    
         OxyMouseDownEventArgs args = ConverterExtensions.ToMouseDownEventArgs(e, sender);
        if (cols != null)      
        {         
             TrackerHitResult nearestPoint = cols.GetNearestPoint(args.Position, false);           
             if(nearestPoint != null) {
                object selectedColumn = nearestPoint.Item;
             }
        }
    }
