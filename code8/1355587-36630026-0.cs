    System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection();
    connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Etay\Documents\Visual Studio 2012\WebSites\Josef\Shared\users.mdb";
    try
    {
        System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand();
        command.Connection = connection;
        connection.Open();
        command.CommandText = "INSERT INTO users (userName, passWord, Uname, pic, privacy) VALUES (?, ?, ?, ?, ?)";
        System.Data.OleDb.OleDbParameters.Add(userName);
        System.Data.OleDb.OleDbParameters.Add(pass);
        System.Data.OleDb.OleDbParameters.Add(name);
        System.Data.OleDb.OleDbParameters.Add(pic);
        System.Data.OleDb.OleDbParameters.Add(privacy);
        command.ExecuteNonQuery();
        Response.Redirect("../HtmlPage.html");
    }
    finally
    {
        connection.Close();
    }
