    var grid = sender as Grid;
    
    if(grid != null)
    {
      var background = grid.Background as SolidColorBrush;
      
      if(background != null)
      {
        var color = background.Color;
    
        if(Colors.Green.Equals(color))
        {
           co = "Audited";
        }
        else if(Colors.Red.Equals(color))
        {
          co = "DoNotAudit";
        }
        else if(Colors.Orange.Equals(color))
        {
          co = "ReAudit";
        }
        else if(Colors.Yellow.Equals(color))
        {
          co = "TobeAudited";
        }
      }
    }
