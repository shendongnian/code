     private void Form1_Load(object sender, EventArgs e)
            {
                LoadCombo(clubSelectorbox1, "select club from teams");
                //now just change the control and the query as needed
                LoadCombo(clubSelectorbox2, "select club from teams");
            }
     private function LoadCombo(DropDownControl myCombo, string query){
    string MyConString = "Server=localhost;Port=3307;Database=database1;UID=root;Password=toor";
                MySqlConnection connection = new MySqlConnection(MyConString);
                MySqlCommand command = connection.CreateCommand();
                MySqlDataReader Reader;
                command.CommandText = query; // use query here
                connection.Open();
                Reader = command.ExecuteReader();
                while (Reader.Read())
                {
                    string thisrow = "";
                    for (int i = 0; i < Reader.FieldCount; i++)
                        thisrow += Reader.GetValue(i).ToString() + " ";
                    myCombo.Items.Add(thisrow); //use myControl here
                }
                connection.Close();
           }
