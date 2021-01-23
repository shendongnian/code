    //declare your variable.  I added a connection and command so I can include parameters in the process.
    string orderBy = "";
    string whereClause = "";
    string sql = "";
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
    if (string.IsNullOrEmpty(Request["search"]))
    {
        whereClause = string.Format(" where Product_Keywords like '%{0}%'", Request["search"]); // very unsafe to plug this in.  should use parameter
    }
    sql = string.Format("SELECT * FROM Products{0} {1}",whereClause, orderBy); //build your query string.  if no search parameter was given the where clause will be blank, but the order by will still exist.
    @foreach (var row in db.Query(sql))
    {
        //some code here
    }
    
