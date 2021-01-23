    private void DGV_DragDropData(object sender, DragEventArgs e)
    {
       Point clientPoint = DGV.PointToClient(new Point(e.X, e.Y));
       rowIndexOfItemUnderMouseToDrop =
           DGV.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
       if (e.Effect == DragDropEffects.Move)
       {
          DataGridViewRow rowToMove = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
          // find the row to move in the datasource:
          DataRow oldrow = ((DataRowView)rowToMove.DataBoundItem).Row;
          // clone it:
          DataRow newrow = bsPeople.NewRow();
          newrow.ItemArray = oldrow.ItemArray;
          bsPeople.Rows.InsertAt(newrow, rowIndexOfItemUnderMouseToDrop);
          bsPeople.Rows.Remove(oldrow);
       }
    }
