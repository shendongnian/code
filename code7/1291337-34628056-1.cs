     private void submit_button_Click(object sender, EventArgs e)
                {
            
         if (!string.IsNullOrEmpty(mytextBox))
        {
    
          MessageBox.Show("your message goes here");
           return ;
         }
            string constring = "datasource=localhost;username=root;password=";
           // insert with parameterised query 
            
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("The Bug have been reported");
                while(myReader.Read())
                {
                }
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
