            DataTable table1 = new DataTable("Items");
            DataColumn column1 = new DataColumn("id", typeof(System.Int32));
            table1.Columns.Add(column1);
            DataTable table2 = new DataTable("details");
            DataColumn column = new DataColumn("Name", typeof(System.Int32));
            table1.Columns.Add(column);
            table1.Merge(table2); //table1 will have 2 columns after executing this line
 
