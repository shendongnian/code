    private void Form1_Load(object sender, EventArgs e)
    {
        //Load data
        //Add columns
        
        //I suppose your desired coulmn is at index 0
        this.dataGridView1.Columns[0].ReadOnly = true;
    }
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        //I suppose your desired coulmn is at index 0
        if (e.ColumnIndex == 0 && e.RowIndex >= 0)
        {
            var result = MessageBox.Show("Check Item?", "", MessageBoxButtons.YesNoCancel);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value = true;
            }
            else
            {
                ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value = false;
            }
        }
    } 
