    private void panel_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(Button).FullName))
        {
            var draggedButton = (Button)e.Data.GetData(typeof(Button).FullName);
            MessageBox.Show(draggedButton.Text);
    
            var screenpos = new Point(e.X, e.Y);
            var clientPos = panel1.PointToClient(screenpos);
            draggedButton.Location = new Point(
                clientPos.X + panel1.Left,
                clientPos.Y + panel1.Top);
        }
    }
