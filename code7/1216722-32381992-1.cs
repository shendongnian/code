    private void MyControl_MouseMove(object sender, MouseEventArgs e)
    {
       if (e.Button == MouseButtons.Left & IsCanDraw)
       {
            this.DoDragDrop(this, DragDropEffects.Move);
            // Disables IsCanDraw method until next drag operation
            IsCanDraw = false;
        }
    }
