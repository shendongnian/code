            string createtableCommandString = @"CREATE TABLE Persons
                                                (
                                                PersonID int,
                                                LastName varchar(255),
                                                FirstName varchar(255),
                                                Address varchar(255),
                                                City varchar(255)
                                                ); ";
            using (SqlConnection connection = new SqlConnection("YourconnectionString"))
            {
                SqlCommand command = new SqlCommand(createtableCommandString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
