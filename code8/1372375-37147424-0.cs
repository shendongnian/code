    var isParentVisible = false;
    
    foreach(Control c in ParentContainer.Controls)
    {
       isParentVisible = c.IsVisible;
       
       if(isParentVisible)
          break;
    }
