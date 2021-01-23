            DateTime datenow = DateTime.Today; 
            string myconnectionstring = @"//connectionstring";
            OleDbConnection myconnection = new OleDbConnection();
            myconnection.ConnectionString = myconnectionstring;
            try
            {
                myconnection.Open();
                ConnectedIcons();
                OleDbCommand command = new OleDbCommand();
                command.Connection = myconnection;
                string update = "UPDATE StaffList SET LastBoot = '" + datenow + "' WHERE StaffID = '" + selectedstaffid + "';";
                var accessUpdateCommand = new  OleDbCommand(update, myconnection);
                accessUpdateCommand.Parameters.AddWithValue("LastBoot", datenow);
                accessUpdateCommand.Parameters.AddWithValue("StaffID", selectedstaffid);
                command = accessUpdateCommand;
                command.ExecuteNonQuery();
                myconnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
