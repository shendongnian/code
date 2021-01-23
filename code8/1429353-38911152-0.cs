    try
    {
     MySqlDataReader reader = null;
     mcon.Open();
     MySqlCommand command2 = mcon.CreateCommand();
     command2.CommandText = "select * from pointofcontact where Username = ?username";
     command2.Parameters.AddWithValue("?username", tbUsername.Text);
     reader = command2.ExecuteReader();
     if (reader != null && reader.HasRows)
     {
        lblValidate.Text = "Username already exists.";
        **return;**
     }
     else
     {
      MySqlCommand command = mcon.CreateCommand();
      command.CommandText = "insert into pointofcontact (FirstName, LastName,        EmailAddress, ContactNumber, BackupContactNumber, Address, Gender, Username, Password, Status, ProfilePic) values(?firstname, ?lastname, ?emailaddress, ?contactnumber, ?backupcontactnumber, ?address, ?gender, ?username, ?password, ?status, ?image)";
      command.Parameters.AddWithValue("?firstname", firstname);
      command.Parameters.AddWithValue("?lastname", lastname);
      command.Parameters.AddWithValue("?emailaddress", email);
      command.Parameters.AddWithValue("?contactnumber", mobileNumber);
      command.Parameters.AddWithValue("?backupcontactnumber", backupNumber);
      command.Parameters.AddWithValue("?address", homeAddress);
      command.Parameters.AddWithValue("?gender", gender);
      command.Parameters.AddWithValue("?username", username);
      command.Parameters.AddWithValue("?password", password);
      command.Parameters.AddWithValue("?status", status);
      command.Parameters.AddWithValue("?image", imageName);
      command.ExecuteNonQuery();
      }
    }
    catch
    {
      ....
    }
    finally
    {
     mycon.Close();
    }
