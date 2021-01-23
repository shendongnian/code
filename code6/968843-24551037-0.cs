    database acces ? 
    
    query; 
    
    OleDbDataReader readername;
    OleDbCommand commandname = new OleDbCommand("Select textBox1.Text=@"+textBox1.Text+" from tablename",connectionname);
    
    connectionname.Open();
    readername = commandname.ExecuteReader();
    while (readername.Read()) //the result
    {
    label1.Text = readername[textbox1.Text].ToString(); 
    }
    connectionname.Close();
