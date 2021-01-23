    using (SqlConnection scn = new SqlConnection("Data Source = 'PAULO'; Initial Catalog=ShoppingCartDB;Integrated Security =True"))
    //I hope this is correct. Else "Server=PAOLO;Database=ShoppingCartDB;Integrated Security=True"
    {
        scn.Open();
    /*
        SqlCommand cmd = new SqlCommand(@"UPDATE UserData SET CreditRequest = 
        (SELECT CAST(REPLACE(c.CreditRequest, ',', '') as int) 
        FROM CreditRequests c Where c.Username=@Username", scn);
    */
        //SQL statement is all wrong and can update all rows
        //Correct is
        SqlCommand cmd = new SqlCommand(@"UPDATE UserData SET CreditRequest = "
            + "CAST(REPLACE(c.CreditRequest, ',', '') as int) "
            + " FROM CreditRequests c inner join UserData u "
            + "on c.Username=u.Username Where c.Username=@Username", scn);
        cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = (string)Session["New"]; //This is good
    
        cmd.ExecuteNonQuery();
    }
