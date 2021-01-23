    // xmlData from form
    string xmlData = "<note> <to>Me</to> <from>You</from> <heading>Reminder</heading> <body>Don\'t forget to buy milk.</body> </note>";
    // this replace is necessary because we need two apostrophe ('') to avoid sql syntax error.
    // Also is necessary to filter xml data for SQL Injection
    string filteredXmlData = xmlData.Replace("'", "''"); 
    
    string CS= @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\TestProjects\Database.mdf;Integrated Security=True";
    SqlConnection sqlCon= new SqlConnection(CS);
    SqlCommand cmd = new SqlCommand("INSERT INTO MyTable (MyCol) values (@paramValue)", sqlCon);
    cmd.Parameters.Add(new SqlParameter("@paramValue", filteredXmlData));
    
    sqlCon.Open();
    int rowsAffected = cmd.ExecuteNonQuery();
    sqlCon.Close();
            
