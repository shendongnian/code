    int id, age; 
    bool idIsInt = false, ageIsInt = false;
    idIsInt = Int32.TryParse(idTextBox.Text, out id);
    ageIsInt = Int32.TryParse(ageTextBox.Text, out age);
 
    if(idIsInt && ageIsInt)
    {
     string query = "INSERT INTO dbo.dataTable(Id,Name,Age) VALUES(" 
            + id + ",'" + nameTextBox.Text + "'," 
            + age + ")";
     SqlConnection conn = 
     new SqlConnection(@"Data Source(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\employee.mdf
           ;Integrated Security=True;Connect Timeout=30");
       
     SqlCommand cmd;
     conn.Open();
     cmd = new SqlCommand(query, conn);
     cmd.ExecuteNonQuery();
    }
