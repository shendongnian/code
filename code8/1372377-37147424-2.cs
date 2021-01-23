    var isParentVisible = false;
    
    foreach (var child in LogicalTreeHelper.GetChildren(ParentContainer)) 
    {
      if (!(child is UIElement)) {
        continue;
      }
      
      isParentVisible = child.IsVisible;
           
      if(isParentVisible)
        break;
    } 
