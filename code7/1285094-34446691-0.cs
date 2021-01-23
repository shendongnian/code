    using (var db = new ABCEntities()){
	  var columnExp = "columnName";
      var query = db.LOCATIONs;
      if(sort_order = "ASC")
      {
          query = query.OrderBy(columnExp).Tolist();  
      }
      else
      {
          query = query.OrderByDescending(columnExp).Tolist();
      }
    }
