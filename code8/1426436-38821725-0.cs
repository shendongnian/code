    private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
    {
        repositoryItemComboBox1.Items.Clear();
        for (int i = 0; i < gridView1.RowCount; i++)
        {
            var genre = gridView1.GetDataRow(i)["genre"].ToString();
            if(!repositoryItemComboBox1.Items.Contains(genre))
            {
                repositoryItemComboBox1.Items.Add(genre);
            }
        }
    }
