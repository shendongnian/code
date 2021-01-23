    OleDbConnection conexao = new OleDbConnection();
    try
    {
        string query2 = "update Utilizador set Nome='" + nomeTextBox.Text + "' , DiaNascimento='" + diaNascimentoComboBox.Text + "'  ,MesNascimento='" + mesNascimentoComboBox.Text + "'  ,AnoNascimento='" + anoNascimentoComboBox.Text + "' , Altura='" + alturaTextBox.Text + "' , Sexo='" + sexoComboBox.Text + "' , Peso='" + pesoTextBox.Text + "' , CodGenetica='" + codGeneticaTextBox1.Text + "', Login='" + loginTextBox.Text + "'  , Password='" + passwordTextBox.Text + "' where CodUtilizador='" + codutilizaor.Text + "'";
        string id = codutilizaor.Text;
        string command = "update Utilizador set Nome= '" + nomeTextBox.Text + "' , Login= " + loginTextBox.Text + " where CodUtilizador= '" + id + "'  ";
        
        conexao.Open();    
        var commandOne = new OleDbCommand(query2, conexao);
        commandOne.ExecuteNonQuery()
        var commandTwo = new OleDbCommand(command, conexao);
        commandTwo.ExecuteNonQuery();   
        conexao.Close();
        
        this.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Ya" + ex);
    }
