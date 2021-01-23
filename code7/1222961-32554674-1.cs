    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == TextColumn.Index)
            {
                var textbox = e.Control as TextBox;
                if (textbox != null)
                {
                    textbox.TextChanged += textboxColumn_TextChanged;
                }
            }
        }
        private void textboxColumn_TextChanged(object sender, EventArgs e)
        {
            int itemIndex = GetCorrectItem();
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[ComboBoxColumn.Index].Value = ComboBoxColumn.Items[itemIndex];
        }
