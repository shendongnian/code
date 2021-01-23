    string LaConexion = @"<MyConnectionString>";
            private DataTable dtTopHalf;
            private DataTable dtBottomHalf;
    
            protected void TextDate_TextChanged(object sender, EventArgs e)
            {
                if (diasemana.Value == "Monday")
                {
                    using (SqlConnection conexion = new SqlConnection(LaConexion))
                    using (SqlCommand comando = new SqlCommand("SELECT [1Monday].IDBatch, Batch.Nombre, Dealer.DealerCodigo, Batch.CTStart, BatchDatos.Estado FROM [1Monday] INNER JOIN Batch ON [1Monday].IDBatch = Batch.IDBatch INNER JOIN Dealer ON Batch.IDDealer = Dealer.IDDealer LEFT OUTER JOIN BatchDatos ON [1Monday].ID = BatchDatos.ID ORDER BY Batch.CTStart", conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
                        DataTable dt = new DataTable();
                        dataAdapter.Fill(dt);
                        int halfCount = dt.Rows.Count / 2;
                        dtTopHalf = dt.AsEnumerable().Select(x => x).Take(halfCount).CopyToDataTable();
                        dtBottomHalf = dt.AsEnumerable().Select(x => x).Skip(halfCount).CopyToDataTable();
                    }
                    // Each value in the Repeater indicates if it is the top half or not
                    repeater1.DataSource = new List<bool>() { true };
                    repeater1.DataBind();
                    repeater2.DataSource = new List<bool>() { false };
                    repeater2.DataBind();
                }
            } 
        
