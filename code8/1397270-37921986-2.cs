        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            string item = cb.Text;
            int irow = dataGridView1.CurrentCell.RowIndex;
            if (item != null)
            {
                if (dataGridView1.CurrentCell.ColumnIndex == 0) // This IF is used for handling first combobox event in gridview
                {
                    dataGridView1.Rows[irow].Cells[1].Value = item; // cell index [1] represent DepartmentName
                }
            
            }
               
        }
