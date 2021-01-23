    public void Select(
      TextPointer start, 
      TextPointer end
    )
    In order to get TextPointer, try this (not checked):
  
    TextPointer pointer = document.ContentStart;
    TextPointer start = pointer.GetPositionAtOffset(0);
    TextPointer end = start.GetPositionAtOffset(5);
    rtb.Select (start,end); // for example to select Hello
                     // Then change the font to bold
    
        
