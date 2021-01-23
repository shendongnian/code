       if (loginSuccessful )
       {
           int userType = Convert.ToInt32(ds.Tables[0].Rows[0]["UserType"]);
           if(userType == 1)
           {
               // User is an administrator, go to admin form
           }
           else if(userType == 2) 
           {
               // User is a normal user, go to user form
           }
           else
           {
               // Unexpected value, error message?
           } 
       }
