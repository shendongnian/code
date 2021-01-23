    //declare your variable.  I added a connection and command so I can include parameters in the process.
    string orderBy = "";
    string whereClause = "";
    var connection = new SqlConnection();
    connection.Open();
    var command = new SqlCommand();
    command.Connection = connection; //assign the connection to the command
    //create your order by clause
    switch (Request["sort"])
    {
        case "PriceASC":
            orderBy = "order by Product_Price ASC";
            break;
        case "PriceDESC":
            orderBy = "order by Product_Price DESC";
            break;
        default:
            orderBy = "ORDER BY Product_ID";
            break;
    }
    //create your where clause.  
    if (string.IsNullOrEmpty(Reqest["search"]))
    {
        whereClause = " where Product_Keywords like '%@productKeyword%'"; //using @productKeyword creates a parameter that you can assign a value to which will help prevent against sql injection attacks. very important to do it this way.
        command.Parameters.AddWithvalue("productKeyword",Request["search"]); //assign the parameter
    }
    string sql = string.Format("SELECT * FROM Products{0} {1}",whereClause, orderBy); //build your query string.  if no search parameter was given the where clause will be blank, but the order by will still exist.
    
    
