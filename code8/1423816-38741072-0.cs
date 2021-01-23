      var list = employees.AsEnumerable().Select(row =>
    			new 
    			{
    				FirstName = row.Field<string>("FirstName"), // Column name was not specified please change this
    				LastName = row.Field<string>("LastName") // As well as this column
    			}).ToList();
    var serializer = new JavaScriptSerializer();
    var json = serializer.Serialize(list);
