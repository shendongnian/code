    private void grid_DragOver(object sender, DragEventArgs e)
    {
        // Get the row index of the item the mouse is below. 
        Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));
        DataGridView.HitTestInfo hit = dataGridView1.HitTest(clientPoint.X, clientPoint.Y);
        if (hit.Type == DataGridViewHitTestType.Cell) {
            e.Effect = (hit.RowIndex%2 == 0)  //move when odd index, else none
                ? DragDropEffects.None
                : DragDropEffects.Move;
        }
    }
