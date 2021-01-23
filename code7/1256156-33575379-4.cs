    var criterias = new List<string>();
    if(categoryComboBox.SelectedIndex > 0)
        criterias.Add(string.Format("CategoryId = {0}", categoryComboBox.SelectedValue);
    if(cityComboBox.SelectedIndex > 0)
        criterias.Add(string.Format("CityId = {0}", cityComboBox.SelectedValue);
    var table = ((DataTable)dataGridView1.DataSource);
    table.DefaultView.RowFilter = string.Join(" And " , criterias);
