      private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;
            dataGridView1.Rows[0].Selected = true;  // select rows
            dataGridView1.Rows[1].Selected = true;  // you want 
            dataGridView1.Rows[2].Selected = true;  // to delete
            int selectedCount = dataGridView1.SelectedRows.Count; 
            while (selectedCount > 0)   
            {
                if (!dataGridView1.SelectedRows[0].IsNewRow)
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                selectedCount--;
            }  
            dataGridView1.ClearSelection(); // to cancel auto-selection after the deleting
        }
