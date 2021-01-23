    using(var conn = new DataConnection()) {
      var toBeUpdated = new List<MyDataType>();
      var toBeDeleted = new List<MyDataType>();
    
     var dataset = conn.Get<MyDataType>().ToList();
     for(var data in dataset) {
       if(...) {
        .....
        toBeUpdated.Add(data);
       }
     }
     .....
     .....
    
     conn.Update(toBeUpdated);
     conn.Delete(toBeDeleted);
    }
