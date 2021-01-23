    public class Address
    {
        public int? AddressID { get; set; }
        public string City { get; set; }
    }
    public class Account
    {
        public int? AccountID { get; set; }
        public string Name { get; set; }
        public List<Address> Addresses { get; set; }
    }
    
    
    public class AccountRepository
    { 
        public void Save(Account newAccount)
        {
            using (var conn = new SqlConnection())
            {
                conn.Open();
                var tran = conn.BeginTransaction();
    
                try
                {
                    //add account
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Transaction = tran;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @" 
    INSERT INTO Accounts 
    VALUEs (@p_account_name);
    
    SET @p_account_ID = scope_identity(); 
    ";
    
                    //param to get account ID
                    var accountID = new SqlParameter("p_account_id", typeof(int));
                    accountID.Direction = ParameterDirection.Output;
    
                    cmd.Parameters.Add(accountID);
                    cmd.Parameters.AddWithValue("p_account_name", newAccount.Name);
                    cmd.ExecuteNonQuery();
    
                    newAccount.AccountID = (int)accountID.Value;
    
                    if (newAccount.Addresses.Count > 0)
                    {
                        //add address
                        foreach (var address in newAccount.Addresses)
                        {
    
                            cmd = new SqlCommand();
                            cmd.Connection = conn;
                            cmd.Transaction = tran;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = @" 
    INSERT INTO Address (account_id, city)
    VALUEs (@p_account_id, @p_city);
    
    SET @p_address_ID = scope_identity(); 
    ";
                            //param to get address ID
                            var addressID = new SqlParameter("p_address_id", typeof(int));
                            addressID.Direction = ParameterDirection.Output;
    
                            cmd.Parameters.Add(addressID);
                            cmd.Parameters.AddWithValue("p_account_id", newAccount.AccountID);
                            cmd.Parameters.AddWithValue("p_city", address.City);
    
                            cmd.ExecuteNonQuery();
                            address.AddressID = (int)addressID.Value;
                        }
                    }
    
    
                    //commit transaction
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw;
                }
    
            }
        }
    }
