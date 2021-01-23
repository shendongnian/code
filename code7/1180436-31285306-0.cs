    DataView view1 = new DataView(myDataSet.Tables[0]);
    DataTable table1 = view.ToTable("Table1", true, "col1", "col3", "col4", "col5", "col6");
    
    
    DataView view2 = new DataView(myDataSet.Tables[0]);
    DataTable table2 = view.ToTable("Table2", true, "col2", "col7", "col8");
