            private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == TextColumn.Index && ComboBoxColumn.Items.Count >0)
            {
                int itemIndex = GetCorrectItem();
                dataGridView1.Rows[e.RowIndex].Cells[ComboBoxColumn.Index].Value = ComboBoxColumn.Items[itemIndex];
            }
        }
