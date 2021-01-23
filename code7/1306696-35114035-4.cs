    public void Select(
      TextPointer start, 
      TextPointer end
    )
    rtb.Select (0,5); // for example to select Hello
                     // Then change the font to bold
    In order to get TextPointer, try this (not checked):
  
    TextPointer pointer = document.ContentStart;
    TextPointer start = pointer.GetPositionAtOffset(0);
    TextPointer end = start.GetPositionAtOffset(5);
    
    
        
