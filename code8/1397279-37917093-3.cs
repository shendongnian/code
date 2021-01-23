    AodIdeal objAodIdeal= new AodIdeal(); 
    while (sqr.Read())
    {
        objAodIdeal.PostID = int.Parse(sqr["PostID"].ToString());
        objAodIdeal.dateposted= sqr["dateposted"].ToString();
        // assign rest of properties
    }
    string requiredString= objAodIdeal.ToString();
   
