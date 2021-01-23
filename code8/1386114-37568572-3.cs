    SqlCommand select =  new SqlCommand(@"SELECT acct_number AS AccountNo,
        cust_lname AS Name 
        FROM List ");
    
    if(!string.IsNullOrWhiteSpace(orderDate)) // use appropriate logic according to data type. I'm assuming string atm.
    select.Parameters.Add(new SqlParameter() { ParameterName = "@ordr_date", Value = orderDate, SqlDbType = SqlDbType.NVarChar });
     // Repeat for each parameter and then...
     for(int i = 0; i < select.Parameters.Count; i++)
     {
         if(i == 0)
             select.CommandText += " WHERE ";
         else
             // OR as in the filter is not exclusive... depends on the filter logic you want to construct of course. 
             // AND if it has to fulfill all properties
             select.CommandText += " OR ";
         select.CommandText += string.Format("{0} = {0}", select.Parameters[i].Name).Substring(1);
     }
