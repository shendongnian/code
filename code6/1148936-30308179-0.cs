    int checkBoxColumnIndex = nnn; // 0 based index of checkboxcolumn
    private void button1_Click(object sender, EventArgs e)
    {
        List<string> checkedItems = new List<string>();
        dataGridView1.ClearSelection();
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            DataGridViewCheckBoxCell checkBox= row.Cells[checkBoxColumnIndex] as DataGridViewCheckBoxCell;
            if (Convert.ToBoolean(checkBox.Value) == true)
            {                    
                 checkedItems.Add(row.Cells[1].Value.ToString());
            }
        }
        if (checkItems.Count > 0)
            MessageBox.Show("Row Content -\r\n" + String.Join("\r\n", checkedItems));
        else
            MessageBox.Show("No row is selected!");
    }
