        DialogResult dr = MessageBox.Show("Deseja mesmo gravar estas alterações?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        if (dr == DialogResult.Yes)
        {
            string con = "server=localhost;userid=root;password=12345;persistsecurityinfo=True;database=portaria";
            string query = "Insert into entradas(id_veiculo,empresa_visitante,empresa_visitar,nome_condutor,visitado,ncartao,data,hora,obs) values(@msktxtmat, @txtempvis, @comboBox1, @txtnomecondutor, @txtpessoavisitar, @txtncartao, @dateTimeFirst, @dateTimeSeconds, @txtobs);";
            MySqlConnection Con = new MySqlConnection(con);
            MySqlCommand Command = new MySqlCommand(query, Con);
            Command.Parameters.AddWithValue("@msktxtmat", msktxtmat.Text);
            Command.Parameters.AddWithValue("@txtempvis", txtempvis.Text);
            Command.Parameters.AddWithValue("@comboBox1", comboBox1.SelectedValue);
            Command.Parameters.AddWithValue("@txtnomecondutor", txtnomecondutor.Text);
            Command.Parameters.AddWithValue("@txtpessoavisitar", txtpessoavisitar.Text);
            Command.Parameters.AddWithValue("@txtncartao", txtncartao.Text);
            Command.Parameters.AddWithValue("@dateTimeFirst", DateTime.Now.Date);
            Command.Parameters.AddWithValue("@dateTimeSeconds", DateTime.Now.Date);
            Command.Parameters.AddWithValue("@txtobs", txtobs.Text);
            MySqlDataAdapter sda = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            sda.SelectCommand = Command;
            sda.Fill(dt);
        }
