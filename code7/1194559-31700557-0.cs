    using(var myAccessConn = myAccessConnection());
    using(var myAccessCommand = myAccessConn.CreateCommand())
    {
        myAccessCommand.CommandText = @"insert into Particulars (Title,FirstName,LastName,Nationality,PassportNumber,PhoneNumber) 
                                        VALUES(?, ?, ?, ?, ?, ?)";
        for (i = 0; i < 100; i++)
        {
            myAccessCommand.Parameters.Clear();
            myAccessCommand.Parameters.AddWithValue("?", titlecomboBox.Items[i].ToString());
            myAccessCommand.Parameters.AddWithValue("?", firstnametextBox.Text);
            myAccessCommand.Parameters.AddWithValue("?", lastnametextBox.Text);
            myAccessCommand.Parameters.AddWithValue("?", nationalitycomboBox.Items[i].ToString());
            myAccessCommand.Parameters.AddWithValue("?", passporttextBox.Text);
            myAccessCommand.Parameters.AddWithValue("?", phonenotextBox.Text); 
            myAccessConn.Open();
            myAccessCommand.ExecuteNonQuery();
        }
    }
