    void columns_MouseDown(object sender, OxyMouseDownEventArgs e)  
    {         
        var cols = sender as ColumnSeries;    
        if (cols != null)      
        {         
             TrackerHitResult nearestPoint = cols.GetNearestPoint(e.Position, false);           
             if(nearestPoint != null) {
                object selectedColumn = nearestPoint.Item;
             }
        }
