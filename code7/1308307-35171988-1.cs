    DataObject o = (DataObject)Clipboard.GetDataObject();
    if (o.GetDataPresent(DataFormats.Text))
    {
        string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
        int j = 0;
        foreach (string pastedRow in pastedRows)
        {
            string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });
            dataGridView1.Rows.Add();
            int myRowIndex = dataGridView1.Rows.Count - 1;
            using (DataGridViewRow myDataGridViewRow = dataGridView1.Rows[j])
            {
                for (int i = 0; i < pastedRowCells.Length; i++)
                    myDataGridViewRow.Cells[i].Value = pastedRowCells[i];
            }
            j++;
        }
    }
