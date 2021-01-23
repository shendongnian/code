    //Set a default
    int int_page_number = 1;
   
    //Check there is a value in the query string for page
    if(!String.IsNullOrEmpty(Request.QueryString["page"]))
    {
         //Try to parse the query string value to an integer
         if(! int.TryParse(Request.QueryString["page"] , out int_page_number))
         {
             //Revert back to 1 if it fails
             int_page_number = 1;
         }
    }
