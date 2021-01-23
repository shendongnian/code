        string connection = @"datasource=xxx;port=xxx;username=root;password=xxx";
        MySqlConnection conn = new MySqlConnection(connection);
        MySqlCommand add = conn.CreateCommand(); // important
        add.CommandText= "Insert Into pap.testes (Cod_Teste,Data,Hora,Cod_Modulo,N_Processo,Nome_Teste) Values ("+ this.cod_teste.Text + "," + this.data.Text + "," + this.hora.Text + ","+ this.modulos.Text +" , " +@Entrada.PassingLoginText+ " ," + this.nome_teste.Text + " )";
        MySqlDataReader reader;
        try
        {
            conn.Open();
            reader = add.ExecuteReader();
            MessageBox.Show("Registo Inserido");
            while(reader.Read())
            {
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finaly
        {
             conn.Close();
        }
