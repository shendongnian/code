    static void Main(string[] args)
        {
            // create table 
            DataTable sampleDataTable = new DataTable("Bar_of_4");
            // create row
            DataRow sampleDataRow = sampleDataTable.NewRow();
            // create column
            DataColumn column;
            // set info about the first column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "bar";
            sampleDataTable.Columns.Add(column);
            // set info about the second column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "first";
            sampleDataTable.Columns.Add(column);
            // add column data to the first row
            sampleDataRow["bar"] = "RRRR";
            sampleDataRow["first"] = "R";
            sampleDataTable.Rows.Add(sampleDataRow);
            // add column data to the second row
            sampleDataRow = sampleDataTable.NewRow();
            sampleDataRow["bar"] = "SSSS";
            sampleDataRow["first"] = "S";
            sampleDataTable.Rows.Add(sampleDataRow);
            // loop through each row and display the column info
            foreach (DataRow row in sampleDataTable.Rows)
            {
                Console.WriteLine(string.Format("{0} - {1}",row["bar"],row["first"]));
            }
            Console.WriteLine("\n\nPress any key to continue");
            Console.ReadKey();
        }
