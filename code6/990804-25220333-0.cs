        private void button2_Click(object sender, EventArgs e)
        {
            string myConnection = connection;
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDataBase = new MySqlCommand("UPDATE `users` SET username='Test' WHERE username='CurrentName' ", myConn);
            MySqlDataReader myReader;
            try
            {
                myConn.Open();
                myReader = cmdDataBase.ExecuteReader();
                myConn.Close();
                MessageBox.Show("Changes has been saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
