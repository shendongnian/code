    dt.Rows.AsEnumerable()
           .Select(r=> new exampleModel()
                  {
                       Id =  r.Field<int>("col1"),
                       Name = r.Field<string>("col2"),
                       ...
                  }); 
