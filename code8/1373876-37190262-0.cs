     public void Insert()
     {
         //myDb = new OleDbConnection(conn + dbFile);
         myDb.Open();
    
         OleDbCommand cmd = new OleDbCommand("INSERT INTO Employee(Username, Password, email, phone) VALUES ('" + insUn + "','" + insPass + "','" + insNm + "','" + insNmr + "')", myDb);
    
         OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
    
         cmd.ExecuteNonQuery();
    
         DataSet ds = new DataSet();
         adapter.Fill(ds, "Employee");
    
         dataGridView1.DataSource = ds;
         dataGridView1.DataMember = "Employee";
    
         myDb.Close();
     }
