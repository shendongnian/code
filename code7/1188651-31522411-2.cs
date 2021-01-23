    from row1 in table1.AsEnumerable()
    join row2 in table2.AsEnumerable() on
      new { userName = row1.Field<string>("USER_NAME"), client = row1.Field<string>("CLIENT") }
    equals
      new { userName = row2.Field<string>("USER_NAME"), client = row2.Field<string>("CLIENT") }
    select new {
        userName = row1.Field<string>("USER_NAME"),
        client = row1.Field<string>("CLIENT"),
        totalOrders = row2.Field<int>("TOTAL_ORDERS"),
        (...)
    }
