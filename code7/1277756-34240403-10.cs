     private void button1_Click(object sender, EventArgs e)
        {
            int selectedCount = dataGridView1.SelectedRows.Count;
            while (selectedCount > 0)
            {
                if (!dataGridView1.SelectedRows[0].IsNewRow)
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                selectedCount--;
            }
            dataGridView1.ClearSelection(); // to cancel auto-selection after the deleting
        }
    }
