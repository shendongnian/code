    using (var ctx = new ClientContext("<site url>"))
    {
               
        var list = ctx.Web.Lists.GetByTitle("Employee Cars"); //get List by its title
        var qry = new CamlQuery { ViewXml = "<View><Query><Where><Gt><FieldRef Name='Year_x0020_of_x0020_Production' /><Value Type='Integer'>2005</Value></Gt></Where></Query></View>" };  //construct the query: [Production Year] > 2005, Year_x0020_of_x0020_Production is the internal name for a field 
        var items = list.GetItems(qry);  //get items using the specified query
        ctx.Load(items); // tell SharePoint to return list items  
        ctx.ExecuteQuery(); //submit query to the server 
        //print results
        foreach (var item in items)
        {
           Console.WriteLine(item.FieldValues["Model"]);
        }
     }
