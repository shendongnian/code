    SqlConnection con = new SqlConnection(@"DataSource=RICHARD\MSSQLSERVER12;Initial Catalog=MojoGegevens;Integrated Security=True");
    
        con.Open();
        sql += "update tblOpmaak set Themakleur = 'red'";
    
        SqlDataAdapter DA = new SqlDataAdapter(sql, con);
        DataSet DS = new DataSet();
        
        SqlCommand Cmd = new SqlConnection(sql, conn);
        Cmd.ExecuteNonQuery();
        con.Close();
