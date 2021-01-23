    List<RowItem> rowItems;
    using(var ctx = new OracleEntities()){
      rowItems = ctx.Customer
        .Where(o => o.id == customerID)
        .Select(
          new RowItem
          {
            ID = Convert.ToInt32(row["ID"]),
            Name = row["Name"].ToString(),
            //the rest of the properties
          }
        ).ToList();
    }
    return rowItems;
