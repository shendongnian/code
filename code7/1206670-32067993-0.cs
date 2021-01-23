    // On mouse down event.
    int mouseDownX = MousePosition.X;
    
    // On mouse up event.
    int mouseUpX = MousePosition.X;
    
    // Check direction.
    if(mouseDownX < mouseUpX)
    {
        // Left to Right selection.
        int index = textBox.SelectionStart;   
    }
    else
    {
        // Right to Left selection.
        int index = textBox.SelectionStart + textBox.SelectionLength;
    }
