    private void lvDrop_DragDrop(object sender, DragEventArgs e)
    {
        var rows = e.Data.GetData(typeof(DataGridViewSelectedRowCollection)) 
                    as DataGridViewSelectedRowCollection;
    
        if(rows.Count > 0)
        {
            foreach(DataGridViewRow row in rows)
            {
                lvDrop.Items.Add(row.Cells[0].Value.ToString());
            }
        }
    }
    
    private void lvDrop_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Move;
    }
    
    private void dgvDrag_MouseMove(object sender, MouseEventArgs e)
    {
        if(e.Button == MouseButtons.Left)
        {
            dgvDrag.DoDragDrop(dgvDrag.SelectedRows, DragDropEffects.Move);
        }
    }
