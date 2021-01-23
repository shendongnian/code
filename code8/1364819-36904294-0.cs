            if (usrname.HasRows)
            {
                while (usrname.Read())
                {
                     if (usrname.GetString(0) == userdigtext){
                         // messagebox here for success
                     }
                     else {
                         // messagebox here for failure
                     }
                }
            }
