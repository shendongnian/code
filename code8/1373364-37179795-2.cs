    if (!Table1.Items.Any())
        return;
    string strInsertCmd = 
        "insert into tbl_srsdata(id,field,[type_of_control],datatype,length,other_buisness_rules)"+
        "values(@id,@field,@type,@datatype,@len,@buis)";
    using (var com = new System.Data.SqlClient.SqlCommand(strInsertCmd, objconn.con))
    {
        var rows = Table1.Items;
        int id;
        id = Redirect.identity;
        MessageBox.Show(id.ToString());
        for (int i = 0; i < rows.Count; i++)
        {
            DataGridRow row = (DataGridRow)Table1.ItemContainerGenerator.ContainerFromIndex(i);
            var field = Table1.Columns[0].GetCellContent(row) as TextBlock;
            var type = Table1.Columns[1].GetCellContent(row) as TextBlock;
            var datatype = Table1.Columns[2].GetCellContent(row) as TextBlock;
            var len = Table1.Columns[3].GetCellContent(row) as TextBlock;
            var buis = Table1.Columns[4].GetCellContent(row) as TextBlock;
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@id", id);
            com.Parameters.AddWithValue("@field", field.Text);
            com.Parameters.AddWithValue("@type", type.Text);
            com.Parameters.AddWithValue("@datatype", datatype.Text);
            com.Parameters.AddWithValue("@len", len.Text);
            com.Parameters.AddWithValue("@buis", buis.Text);
            com.ExecuteNonQuery();
        }
    }
