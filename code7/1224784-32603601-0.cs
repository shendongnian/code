    private void loadComboBox() {
            myConn = new SqlConnection("Server = localhost; Initial Catalog=dbName; Trusted_Connection = True");
            string query = "Select * from user_Detail";
            myCommand = new SqlCommand(query, myConn);
            try {
                myConn.Open();
                myReader = myCommand.ExecuteReader();
                string s = "<------------- Select an item ----------->";
                itemComboBox.Items.Add(s);
                itemComboBox.Text = s;
                while (myReader.Read()) {
                    //declare a string
                    string userId = myReader["userId"].toString();
                    string userName = myReader["userName"].toString();
                    //my comboBox named userComboBox
                    userComboBox.Items.Add(userName);
                }
                myConn.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
