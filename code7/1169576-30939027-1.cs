    OleDbConnection conexao = new OleDbConnection();
    try
    {
        string query = "update Utilizador set Nome='" + nomeTextBox.Text + "' , DiaNascimento='" + diaNascimentoComboBox.Text + "'  ,MesNascimento='" + mesNascimentoComboBox.Text + "'  ,AnoNascimento='" + anoNascimentoComboBox.Text + "' , Altura='" + alturaTextBox.Text + "' , Sexo='" + sexoComboBox.Text + "' , Peso='" + pesoTextBox.Text + "' , CodGenetica='" + codGeneticaTextBox1.Text + "', Login='" + loginTextBox.Text + "'  , Password='" + passwordTextBox.Text + "' where CodUtilizador='" + codutilizaor.Text + "'";
        
        conexao.Open();    
        var commandOne = new OleDbCommand(query, conexao);
        commandOne.ExecuteNonQuery() 
        conexao.Close();
        
        this.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Ya" + ex);
    }
