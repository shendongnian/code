    private void txtbox_TextChanged(object sender, EventArgs e)
     {
        DataView DV = new DataView(datatable);
        DV.RowFilter = string.Format("ColumnX LIKE '%{0}%'", txtbox.Text);
        dataGridView1.DataSource = DV; 
     }
