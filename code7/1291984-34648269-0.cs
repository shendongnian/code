    public List<int> GetContactInfo()
    {
        List<int> contacts = new List<int>();
        using (SqlConnection conn = new SqlConnection(CS))
        {
           using (SqlCommand cmd = new SqlCommand("select Mobileno,Landno FROM Demo", conn))
           {
               conn.Open();
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {
                      contacts.Add(Convert.ToInt32(reader["Mobileno"]));
                      contacts.Add(Convert.ToInt32(reader["Landno"]));
                   }
               }
            }
        }
        return contacts;
    }
