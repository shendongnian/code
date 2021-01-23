    bool itemFound = false;
    foreach (DataTable dt in ds.Tables)
    {
       foreach (DataRow dr in dt.Rows)
       {
          string firstName = dr["First_name"].ToString();
          string lastName = dr["Last_name"].ToString();
          if (firstName.Trim().ToUpper() == txtFirstName.Text.Trim().ToUpper() && lastName.Trim().ToUpper() == txtLastName.Text.Trim().ToUpper())
          {  
            itemFound = true;
            break;                                        
          }              
       }
     }
    
    if(itemFound)
        Autor.UpdateInDatabase(autor); 
    else
        Autor.AddToDatabase(autor); 
