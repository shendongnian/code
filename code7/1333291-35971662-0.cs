    private void panel_DragOver(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(Button).FullName))
        {
            var draggedButton = (Button)e.Data.GetData(typeof(Button).FullName);
                                 
            var screenpos = new Point(e.X, e.Y);
            var clientPos =  panel1.PointToClient(screenpos);
            // calc offset
            draggedButton.Location = new Point(
                clientPos.X + panel1.Left,
                clientPos.Y + panel1.Top);
        }
    }
