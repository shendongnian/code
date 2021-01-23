    private void RichEditOnGotFocus(object sender, RoutedEventArgs routedEventArgs)
    {
        ITextSelection selectedText = richEdit.Document.Selection;
        if (selectedText != null)
        {
            richEdit.Document.Selection.SetRange(_selectionStart, _selectionEnd);
            selectedText.CharacterFormat.BackgroundColor = Colors.White;
        }
    }
    
    private void RichEditOnLostFocus(object sender, RoutedEventArgs routedEventArgs)
    {
        _selectionEnd = richEdit.Document.Selection.EndPosition;
        _selectionStart = richEdit.Document.Selection.StartPosition;
    
        ITextSelection selectedText = richEdit.Document.Selection;
        if (selectedText != null)
        {
            selectedText.CharacterFormat.BackgroundColor = Colors.Gray;
        }
    }
