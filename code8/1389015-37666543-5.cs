    foreach(DataRow dr in dtUserData.Rows)
    {
       var userData = new UserData();
       // create an array with a single element
       userData.Categories = new [] 
       {
         new Category
         {
           category_id = ??,
           category_name = Convert.ToString(dr["category"])
         }
       };
       // not sure about this:
       userData.UserDetails = new [] 
       {
         new UserDetails
         {
           Whatever = Convert.ToString(dr["userdetails"]),
         }
       };
    }
