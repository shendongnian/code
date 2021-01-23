    SqlConnection con = new SqlConnection(connectionString);  
    SqlCommand cmd = new SqlCommand();  
    cmd.Connection = con;  
    con.Open();  
    foreach (var person in allInvolved)
    {
    nic = person.NIC;
    cmd.CommandText = "select * from criminal where NIC ="+nic;  
    dr3 = cmd.ExecuteReader();
    while (dr3.Read())  
    { 
          if (dr3.HasRows)
          { do something}
          else if (!dr3.HasRows)
          { do something else}
    }
  }
    con.Close(); 
