     public void AddOne(string firstName, string lastName, int num)
     {
          using (cnxn)
          {
              using (SqlCommand sc = new SqlCommand("INSERT INTO TableName VALUES('"+ firstName +"','"+ lastName +"',"+num+")", cnxn))
              {
                  cnxn.Open();
                  sc.ExecuteNonQuery();
                  cnxn.Close();
              }
          }
     }
