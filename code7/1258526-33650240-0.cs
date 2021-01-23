    private void xmlGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        string cellContent = xmlGrid.CurrentCell.Value.ToString();
        MessageBox.Show(cellContent);
        foreach(DataGridViewRow row in Grid1.Rows)
        {
            if(row.Cells[2].Value==cellContent)
            {
                row.Cells[3].Value=cellContent;
                break;
            }
        }
    }
