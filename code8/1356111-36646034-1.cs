    SqlCommand sqlInsertList = new SqlCommand("Insert into linhas (quantidade,descricao,valor) VALUES(@quantidade,@descricao,@valor)", sqlConn);   
    
    sqlConn.Open();                         
    sqlTran = sqlConn.BeginTransaction();
    
    for (int i = 0; i < quantidade.Count; i++)
    {
        sqlInsert.Transaction = sqlTran;
        sqlInsertList.Parameters.Clear();
        sqlInsertList.Parameters.AddWithValue("@quantidade", quantidade[i]);
        sqlInsertList.Parameters.AddWithValue("@descricao", artigo[i]);
        sqlInsertList.Parameters.AddWithValue("@valor", loat.Parse(valor[i], CultureInfo.InvariantCulture.NumberFormat));        
        sqlInsert.ExecuteNonQuery();    
    }         
    sqlTran.Commit();
