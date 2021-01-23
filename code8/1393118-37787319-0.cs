    dTable = ds.Tables[0];
    List<student> studentList=dTable.AsEnumerable().Select(x => new student() { 
                                 ID=x.Field<int>("column_id"),
                                 Name = x.Field<string>("column_Name")
                                 }).ToList();
