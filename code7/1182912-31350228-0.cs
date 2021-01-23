    private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            dragItemID = dataGridView1["ID", e.RowIndex].Value.ToString();
            dataGridView1.DoDragDrop(dragItemID, DragDropEffects.Copy);
        }
    }
