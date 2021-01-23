    public static void AppendText(this RichTextBox Box, 
                                  string Text,    
                                  Color col, 
                                  int SelectionStart)
    {
        // keep all values that will change
        var oldStart = Box.SelectionStart;
        var oldLen = Box.SelectionLength;
        
        // 
        Box.SelectionStart = SelectionStart;
        Box.SelectionLength = 0;
        
        Box.SelectionColor = col;
        // Or do you want to "hide" the text? White on White?
        // Box.SelectionBackColor = col; 
        
        // set the selection to the text to be inserted
        Box.SelectedText = Text;
        
        // restore the values
        // make sure to correct the start if the text
        // is inserted before the oldStart
        Box.SelectionStart = oldStart < SelectionStart ? oldStart : oldStart + Text.Length; 
        // overlap?
        var oldEnd = oldStart + oldLen;
        var selEnd = SelectionStart + Text.Length;
        Box.SelectionLength = (oldStart < SelectionStart && oldEnd > selEnd) ? oldLen + Text.Length :  oldLen;  
    }
