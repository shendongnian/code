    myDataGridView.MouseDoubleClick += dgvMouseDoubleClick;
    private void dgvMouseDoubleClick(object sender, MouseEventArgs e)
    {
        myDataGridView.DefaultCellStyle.SelectionBackColor = Color.Aqua; 
    }
