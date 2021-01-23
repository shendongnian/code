      private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;
            dataGridView1.Rows[0].Selected = true;  // rows
            dataGridView1.Rows[1].Selected = true;  // you want 
            dataGridView1.Rows[2].Selected = true;  // to delete
            int n = 0; 
            while (n != 3)            // until amount of selected rows
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index); 
                n++;
            }  
        }
