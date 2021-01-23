    var isParentVisible = false;
    
    foreach(Control child in ParentContainer.Controls)
    {
       isParentVisible = child.IsVisible;
       
       if(isParentVisible)
          break;
    }
