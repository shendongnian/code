        myConnection.Open();
        Console.WriteLine("Connection Opened");
        String myQuery = "INSERT INTO client([name], surname) values ('" + nameBox.Text "','"+ snameBox.Text + "')";
        OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
        myCommand.ExecuteNonQuery()
