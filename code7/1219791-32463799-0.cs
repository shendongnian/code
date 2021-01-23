      while (objReader.Read())
      {
    
        MailMessage myMessage = new MailMessage();
        myMessage.Subject = "Test Message for " + (objReader.GetValue(1)) + " " + (objReader.GetValue(2));
        myMessage.Body = "This email would be sent to: " + (objReader.GetValue(3));
        myMessage.From = new MailAddress("senderaddress@mydomain.com", "Sender Name");
        myMessage.To.Add(new MailAddress((objReader.GetString(3)), (objReader.GetString(2))));
    
        SmtpClient mySmtpClient = new SmtpClient();
        mySmtpClient.Send(myMessage);
    
        Response.Write("Email sent to: " + (objReader.GetValue(3)) + "<br>");
    
        // Update the table, assuming ID is the first column in the table.
        // This is for demonstration only and it is not the most efficient way
        // of doing this because a new command is created each time. 
        // The correct way would be to move the command and parameters creation
        // outside the loop and just update the parameter values inside the loop.
        SqlCommand UpdateCommand = new SqlCommand("UPDATE EmailTable SET DateSent = @dtSent WHERE id = @thisId", objConnection);
        updateCommand.Parameters.AddWithValue( "@dtSent", DateTime.Now);
        updateCommand.Parameters.AddWithValue( "@thisId", objReader.GetValue(0));
        updateCommand.executeNonQuery();
      }
