    private void listView_GiveFeedback(object sender, GiveFeedbackEventArgs e)
    {
        if (e.Effect == DragDropEffects.Move)
        {
            e.UseDefaultCursors = false;
            Mouse.SetCursor(Cursors.SizeAll);
        }
        else
            e.UseDefaultCursors = true;
    
        e.Handled = true;
    }
