        {
            dataGridView1.Columns.Add("Cat", "Cat");
            dataGridView1.Columns.Add("Dog", "Dog");
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.CellEnter += dataGridView1_CellEnter;    
        }
        void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null)
                return;
            var row = dgv.Rows[e.RowIndex];
            if (row.IsNewRow)
            {
                // Set your default values here
                row.Cells["Cat"].Value = "Meow";
                row.Cells["Dog"].Value = "Woof";
                // Force the DGV to add the new row by marking it dirty
                dgv.NotifyCurrentCellDirty(true);
            }
        }
