    public void getLikeConta(string parametroWhere, string parametroCondicao, DataGridView dataGrid)
    {
        var query = "SELECT nome,usuario,email,administrador FROM GSCUsuarios WHERE @parametroWhere = @parametroCondicao";
    
        SqlConnection con = BancoDados.Criarconexao();
    
        con.Open();
    
        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);
        dataAdapter.SelectCommand.Parameters.AddWithValue("parametroWhere", parametroWhere);
        dataAdapter.SelectCommand.Parameters.AddWithValue("parametroCondicao", parametroCondicao);
    
        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
    
        DataSet ds = new DataSet();
        dataAdapter.Fill(ds);
        dataGrid.ReadOnly = true;
        dataGrid.DataSource = ds.Tables[0];
    
        commandBuilder.Dispose();
        con.Close();
        con.Dispose();
    }
