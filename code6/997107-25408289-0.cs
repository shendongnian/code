    String query = "SELECT * FROM YourTable";
    String extndQuery = "";
    bool and = false;
    if (dropdownlist1.SelectedValue != "Any")
      {
        extndQuery += " Column1=@variable1";
        and = true;
      }
    if (dropdownlist2.SelectedValue != "Any")
      {
        if (and)
        {
         extndQuery += " AND";
        }
        extndQuery += " Column2=@variable2";
        and = true;
      }
    if (and)
    {
      query += " WHERE" + extndQuery;
    }
    
    SelectCommand=query;
