        List<string> columnContentList = new List<string>();
        foreach (DataGridViewRow  row in dataGridView1.Rows)
        {
            columnContentList.Add(row.Cells["ColumnContents"].Value.ToString());
        }
