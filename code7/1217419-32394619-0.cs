     DataContext dc = new   Using(DataContext(Connections.GetDynamicConnectionfromConfig()))
     {
              Sampleclass obj = new Sampleclass();
              //Here assign properties to obj
              dc.tableName.InsertOnSubmit(obj);
              dc.SubmitChanges();
                 
    }
