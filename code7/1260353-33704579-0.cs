    string Query = "SELECT idclient, CONCAT(FIRSTNAME, ' ', LASTNAME) AS NAME,"
         + " CONCAT(STREET, ' ', CITY, ', ', STATE, ' ', ZIPCODE) AS ADDRESS,"
         + "`Contact Number` FROM people.client";
    MySqlConnection myConn = new MySqlConnection(myconnection);
    MySqlCommand cmdDataBase = new MySqlCommand(Query, myConn);
    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
    myDataAdapter.SelectCommand = cmdDataBase;
    DataTable dbdataset = new DataTable();
    myDataAdapter.Fill(dbdataset);
    
    //Set AutoGenerateColumns False
    dataGridView1.AutoGenerateColumns = false;
    //Set Columns Count
    dataGridView1.ColumnCount = 3;
    
    //Add Columns
    dataGridView1.Columns[0].HeaderText = "Name";
    dataGridView1.Columns[0].DataPropertyName = "Name";
    
    dataGridView1.Columns[1].HeaderText = "Address";
    dataGridView1.Columns[1].DataPropertyName = "Adress";
    
    dataGridView1.Columns[2].HeaderText = "Contact Number";
    dataGridView1.Columns[2].DataPropertyName = "Contact Number";
    
    dataGridView1.DataSource = dbdataset;
