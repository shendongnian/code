    private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)    // loop's start to check condition
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value) == -1) // example of condition
                    {
                        dataGridView1.Rows[i].Selected = true;
                        break;
                    }
                }
            }
            int selectedCount = dataGridView1.SelectedRows.Count;
            while (selectedCount > 0)
            {
                if (!dataGridView1.SelectedRows[0].IsNewRow)
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                selectedCount--;
            }
            dataGridView1.ClearSelection();
        }
