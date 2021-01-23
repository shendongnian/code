    private void keyboardTimer_Tick(object sender, object e)
    {
        // Stop timer so it doesn't repeat
         keyboardTimer.Stop();
        // Invoke ChangeView() on NoteContentScrollViewer, and use GetRectFromCharacterIndex to scroll to caret position
        if (NoteContentTextBox.Text != "")
            NoteContentScrollViewer.ChangeView(0, NoteContentTextBox.GetRectFromCharacterIndex(NoteContentTextBox.SelectionStart - 1, true).Y, null);
    }
