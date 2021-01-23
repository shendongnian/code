    private void dataGridView1_MouseHover(object sender, EventArgs e)
    {
        var p = this.dataGridView1.PointToClient(Cursor.Position);
        var info = this.dataGridView1.HitTest(p.X, p.Y);
        //You can use this values
        //info.ColumnX
        //info.RowY
        //info.ColumnIndex
        //info.RowIndex
    }
