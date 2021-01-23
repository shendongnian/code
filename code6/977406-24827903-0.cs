     public class EmployeeDetails
        {
            public string FirstName{ get; set; }
            public string LastName{ get; set; }
    //You can add more property as per your requirement
        }
     List<EmployeeDetails> emp = new List<EmployeeDetails>();
    using (SqlConnection Conn = new SqlConnection(ConnectionString))//ConnectionString from your config file
                    {
                        Conn.Open();
                        using (SqlCommand Cmd = Conn.CreateCommand())
                        {
                            Cmd.CommandText = "dbo.your_proc_name";
                            Cmd.CommandType = CommandType.StoredProcedure;
    
                            using (SqlDataReader dr = Cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    emp.Add(new EmployeeDetails{ FirstName= dr[0].ToString(), LastName= dr[1].ToString()});
                                }
                                dr.Close();
                            }
                        }
                    }
