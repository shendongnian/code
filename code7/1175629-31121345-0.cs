        DataTable ItemTable = new DataTable("MyTable");
        ItemTable.Columns.Add("ID"      , typeof(int   ));
        ItemTable.Columns.Add("ParentID", typeof(int   ));
        ItemTable.Columns.Add("Name"    , typeof(String));
         
        
        // add some test data
        ItemTable.Rows.Add(new object[] { 0,-1, "Bill Gates"    });
        ItemTable.Rows.Add(new object[] { 1, 0, "Steve Ballmer" });
        ItemTable.Rows.Add(new object[] { 3, 1, "Mary Smith"    });
        ItemTable.Rows.Add(new object[] { 2, 0, "Paul Allen"    });
        ItemTable.Rows.Add(new object[] { 4, 2, "Ahmed Jones"   });
        ItemTable.Rows.Add(new object[] { 5, 2, "Wing Lee"      }
    );
