    var table= new DataTable("test");
    table.Columns.AddRange(new [] { 
      new DataColumn("colA",typeof(string)), 
      new DataColumn("colB",typeof(int)),
      new DataColumn("colC",typeof(string))}
    );
    table.Rows.Add("a",1,"abc");
    table.Rows.Add("a",2,"def");
    table.Rows.Add("b",1,"ghi");
    table.Rows.Add("b",2,"jkl");
