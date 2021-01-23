      var commandText = "UPDATE myTable SET Date = getdate() WHERE UserId = @extractedId";
      SqlCommand myCommand = New SqlCommand(commandText);
      myCommand.CommandType = CommandType.Text;
      myCommand.CommandTimeout = 300;
      myCommand.Connection = New SqlConnection(myConnection);
      myCommand.Parameters.AddWithValue("@extractedId", extractedId)
      try 
      {
          var result = myCommand.ExecuteNonQuery();
      }
      catch(Exception e)
      {
          //do something with exception
      }
      finally
      {
         myCommand.Connection.Close()
      }
