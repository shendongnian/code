    private void TextBox_Drop(object sender, DragEventArgs e)
    {
        //  Do whatever
    }
    private void TextBox_DragOver(object sender, DragEventArgs e)
    {
        var ptTargetClient = e.GetPosition(DropTargetGrid);
        if (ptTargetClient.X >= 0 && ptTargetClient.X <= DropTargetGrid.ActualWidth
            && ptTargetClient.Y >= 0 && ptTargetClient.Y <= DropTargetGrid.ActualHeight)
        {
            e.Handled = true;
            e.Effects = DragDropEffects.Move;
        }
    }
