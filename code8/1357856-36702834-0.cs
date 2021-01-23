    public void UpdateCustomerCredentials(long id, string firstName, string lastName, string email, string mobilePhoneNumber, int price, string notes, Guid? imageId = null)
    {
        using (SqlConnection con = new SqlConnection(ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("UpdateCustomer", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.Parameters.Add(new SqlParameter("@FirstName", firstName));
                cmd.Parameters.Add(new SqlParameter("@LastName", lastName));
                cmd.Parameters.Add(new SqlParameter("@Email", email));
                cmd.Parameters.Add(new SqlParameter("@MobilePhoneNumber", mobilePhoneNumber));
                cmd.Parameters.Add(new SqlParameter("@ImageId", GetParamValue(imageId)));
                cmd.Parameters.Add(new SqlParameter("@Price", price));
                cmd.Parameters.Add(new SqlParameter("@Notes", notes));
                try
                {
                    con.Open();
                    cmd.ExecuteReader();
                    con.Close();
                }
                catch (SqlException ex)
                {
                    cmd.Dispose();
                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                }
            }
        }
    }
