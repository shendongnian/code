    bool InEditMode = false;
    Point EditStartLocation;
    private void dgv_TimeCard_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        EditStartLocation = dgv_TimeCard.PointToClient(Cursor.Position);
        InEditMode = true;
    }
    private void dgv_TimeCard_MouseMove(object sender, MouseEventArgs e)
    {
        if (InEditMode == false) return;
        if (Math.Abs(EditStartLocation.X - e.X) > 100 || Math.Abs(EditStartLocation.Y - e.Y) > 100)
        {
            dgv_TimeCard.EndEdit();
            dgv_TimeCard.CurrentCell = dgv_TimeCard.CurrentRow.Cells["Date"];
            InEditMode = false;
        }
    }
