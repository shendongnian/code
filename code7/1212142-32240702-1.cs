    var connection = new System.Data.SqlClient.SqlConnection(@"Your Connection String");
    //Your command: SELECT yy+mm AS yymm, Summ FROM test_recv /*WHERE...*/ ORDER BY yymm ASC
    //Add Whatever WHERE clause you need
    //Pay attention that yy+mm Selected at first and Summ selected at seccond position
    //Pay attention we ORDER BY yymm ASC
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
            //0 is Index of Summ
            var header = reader.GetString(0);
            
            //1 is Index of yymm
            var value= reader.GetString(1);
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
