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
        int DistanceToEndEdit = 50;
        if (Math.Abs(EditStartLocation.X - e.X) > DistanceToEndEdit || Math.Abs(EditStartLocation.Y - e.Y) > DistanceToEndEdit)
        {
            dgv_TimeCard.EndEdit();
            dgv_TimeCard.CurrentCell = dgv_TimeCard.CurrentRow.Cells["Date"];
            InEditMode = false;
        }
    }
    private void dgv_TimeCard_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        InEditMode = false;
    }
