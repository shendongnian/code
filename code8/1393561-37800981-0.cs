        connection.Open();
        OleDbCommand comando = new OleDbCommand();
        comando.Connection = connection;
        comando.CommandText = "SELECT * FROM faturas_online_detalhe WHERE cod_fatura= @parm1;";
        commando.Parameters.AddWithValue("@parm1", codfatura);
        OleDbReader reader = comando.ExecuteReader() ;
        while(reader.Read())
        {
            Console.WriteLine(string.Format("Column 1 = {0}, Column 2 = {1}, etc...", reader.GetString(0), reader.GetString(1)));
        }
        reader.Close();
        connection.Close();
