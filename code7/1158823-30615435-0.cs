    //codigo de pesquisa
            string strconexao = "persist security info =false ; server=localhost ; database= iconefileequipamentos; uid=root";
            MySqlConnection oConn =new MySqlConnection(strconexao);
            StringBuilder strSQL =new StringBuilder();
            DataTable oTable =new DataTable();
            MySqlCommand oCmd =new MySqlCommand();
    
            oConn.Open();
    
            if (comboBox1.Text =="NomeResponsavel")
            {
                string NomeResponsavel = textBox1.Text; 
                //Added white space at end of each line
                strSQL.Append("Select * ");
                strSQL.Append("FROM responsavelpc ");
                strSQL.Append("Where Nomeresponsavel like '" + NomeResponsavel + "'");
            }
    
            if (comboBox1.Text == "NomeEquipamento")
            {
                string NomeEquipamento = textBox1.Text;
                //Added white space at end of each line
                strSQL.Append("Select * ");
                strSQL.Append("FROM responsavelpc ");
                //Added white space after LIKE
                strSQL.Append("Where NomeEquipamento like '" + NomeEquipamento +"'"); 
            }
            MySqlDataAdapter oDA = new MySqlDataAdapter(strSQL.ToString(), oConn);
            oDA.Fill(oTable); hear appears the message that i put as title!
            dataGridView1.DataSource = oTable;
            oConn.Close();           
        }
