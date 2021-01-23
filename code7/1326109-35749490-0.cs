    using (OleDbConnection connection = new OleDbConnection("the_connection_string"))
            using(OleDbCommand command = new OleDbCommand())
            {
                // this part of the query determines whether there is a substitute in the sport or not
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * FROM [Sport] WHERE Substitute = true and SportID = ?";
                command.Parameters.Add("@p1", OleDbType.Integer).Value = Convert.ToInt32(Form1.IDNumber.Text);
        
                if (command.ExecuteScalar() != null)
                    substituteInSport = true;
                else
                    substituteInSport = false;
            }
