    var qry = from r1 in table1.AsEnumerable() //row count - 416
              from r2 in table2.AsEnumerable() //row count - 175
              where
                  r1.Field<string>("Name") == r2.Field<string>("Name")
              select r2;
    var dt = table2.Clone();
    table2.AsEnumerable().Except(qry).ToList().ForEach(x =>
    {
        dt.Rows.Add(x);
    });
    this.dataGridView1.DataSource = dt;
