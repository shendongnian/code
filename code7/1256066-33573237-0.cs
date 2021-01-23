    private void MyGrid_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {    
            var dragSource = ...;
            var data = ...;
            DragDrop.DoDragDrop(dragSource, data, DragDropEffects.Move);
        }
    }
