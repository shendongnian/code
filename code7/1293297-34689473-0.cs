     //I am constructing a data table here. You already have this I guess.
            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("A", typeof(int)) { AllowDBNull = true });
            dataTable.Columns.Add(new DataColumn("B", typeof(int)) { AllowDBNull = true });
            dataTable.Columns.Add(new DataColumn("C", typeof(int)) { AllowDBNull = true });
    //Assign values
            DataRow row1 = dataTable.NewRow();
            row1["A"] = 6;
            row1["B"] = 0;
            row1["C"] = 7;
            dataTable.Rows.Add(row1);
            DataRow row2 = dataTable.NewRow();
            row2["A"] = 0;
            row2["B"] = 7;
            row2["C"] = 0;
            dataTable.Rows.Add(row2);
            DataRow row3 = dataTable.NewRow();
            row3["A"] = 5;
            row3["B"] = 0;
            row3["C"] = 4;
            dataTable.Rows.Add(row3);
    //This is what you need.
            foreach (DataRow row in dataTable.Rows)
            {
                if ((int)row["A"] == 0)
                {
                    row["A"] = DBNull.Value;
                } 
                if ((int) row["B"] == 0)
                {
                    row["B"] = DBNull.Value;
                }
                if ((int) row["C"] == 0)
                {
                    row["C"] = DBNull.Value;
                }
            }
    //test the changes
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine("" + row["A"] + "; " + row["B"] + "; " + row["C"]);
            }
