        string Query = "INSERT into ClientsT (FirstName, LastName, Address, Email, Phone, CellPhone, Notes) values(@FirstName, @LastName, @Address, @Email, @Phone, @CellPhone, @Notes)";
            
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        using (SqlCommand cmd = new SqlCommand(Query))
        {
            connection.Open();
            // Please make sure you edit the SqlDbType to the correct SQL Data Type. They are VarChar by default in this example. It's on you to fix that.
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar) = boxAddName.Text;
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar) = boxAddLastName.Text;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar) = boxAddAddress.Text;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar) = boxAddEmail.Text;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar) = boxAddPhone.Text;
            cmd.Parameters.Add("@CellPhone", SqlDbType.VarChar) boxAddCellPhone.Text;
            cmd.Parameters.Add("@Notes", SqlDbType.VarChar) = boxAddNotes.Text;
            // Insert writing code here.
        }
