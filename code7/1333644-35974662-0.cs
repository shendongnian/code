    DataTable dt = ReadDataTable();
    var rows = from row in dt.AsEnumerable()
               where row.Field<bool>("Active")
               group row by new
               {
                   CollectionId = row.Field<int>("CollectionId"),
                   CollectionName = row.Field<string>("CollectionName"),
               } into grp
               let result = new
               {
                   CollectionId = grp.Key.CollectionId,
                   CollectionName = grp.Key.CollectionName,
                   MaxCreated = grp.Max(r => r.Field<DateTime>("Created")),
               }
               orderby result.MaxCreated descending
               select result;
