     private void submit_button_Click(object sender, EventArgs e)
                {
            
         if (!string.IsNullOrEmpty(mytextBox))
        {
    
          MessageBox.Show("your message goes here");
           return ;
         }
            string constring = "datasource=localhost;username=root;password=";
            string Query = "INSERT INTO bug.bug (Bug_ID, title, Type_of_bug, software, software_version, description, step_to_reproduction, severity, priority, symptom) values('" + this.bugid_txt.Text+"', '" + this.title_txt.Text + "','" + this.comboBox1.Text + "','" + this.software_txt.Text + "','" + this.software_version_txt.Text + "','" + this.description_txt.Text + "','" + this.step_to_reproduction_txt.Text + "','" + this.severity_combo.Text + "','" + this.priority_combo.Text + "','" + this.symptom_txt.Text + "')";
            
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
