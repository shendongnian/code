     void AutoCompleteTxtBox() 
        {
            txt_names.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_names.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "your connection string";
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from your DataBase table name";
            OleDbDataReader myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                string lname = myReader["the column name you want to autocomplete"].ToString();
                coll.Add(lname);
            }
            txt_names.AutoCompleteCustomSource = coll;
            conn.Close();
        }
