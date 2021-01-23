    var connection = new System.Data.SqlClient.SqlConnection(@"Your Connection String");
    var command = new System.Data.SqlClient.SqlCommand("Your Command", connection);
    try
    {
        this.dataGridView1.Columns.Clear();
        this.dataGridView1.Rows.Clear();
        connection.Open();
        var reader = command.ExecuteReader();
        int columnIndex = 0;
        while (reader.Read())
        {
            //Instead of 1 put column index that title of cell is in
            var header = reader.GetString(1);
            
            //Instead of 0 put column index that value of cell is in
            var value= reader.GetInt32(0);
            var column = new DataGridViewTextBoxColumn();
            column.HeaderText = header;
            this.dataGridView1.Columns.Add(column);
            if(dataGridView1.RowCount==0)
                this.dataGridView1.Rows.Add(1);
            this.dataGridView1.Rows[0].Cells[columnIndex].Value = value;
            columnIndex++;
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
    finally
    {
        if (connection.State == ConnectionState.Open)
            connection.Close();
    }
