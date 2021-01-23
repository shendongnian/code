        InsertData("Insert into Products (Name) Values ('" + txtName.Text + "'); Insert Into Auctions (bidvalue) Values ('" + lstBidValues.SelectedValue + "');"); 
        public void InsertData(string query)
        {
            using (SqlConnection con = new SqlConnection("Your connection string here"))
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                }
            }
        }
           
