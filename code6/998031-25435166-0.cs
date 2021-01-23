            DataTable dataTable1 = new DataTable();
            dataTable1.Columns.Add(new DataColumn("Column1", typeof(int)));
            dataTable1.Columns.Add(new DataColumn("Column2", typeof(int)));
            dataTable1.Columns.Add(new DataColumn("Column3", typeof(int)));
            dataTable1.Columns.Add(new DataColumn("Column4", typeof(int)));
            dataTable1.Columns.Add(new DataColumn("Column5", typeof(decimal)));
            dataTable1.Columns.Add(new DataColumn("Column6", typeof(decimal)));
            dataTable1.Rows.Add(123456, 6, 54, 5, 0, 36.78);
            dataTable1.Rows.Add(123456, 6, 54, 5, 21, 0);
            dataTable1.Rows.Add(123456, 6, 54, 8, 0, 102.09);
            dataTable1.Rows.Add(123456, 6, 54, 8, 6.50, 0);
            //Select the rows where columns 1-4 have repeated same values
            var distinctRows = dataTable1.AsEnumerable()
                                    .Select(s => new
                                    {
                                        unique1 = s.Field<int>("Column1"),
                                        unique2 = s.Field<int>("Column2"),
                                        unique3 = s.Field<int>("Column3"),
                                        unique4 = s.Field<int>("Column4"),
                                    })
                                    .Distinct();
            //Create a new datatable for the result
            DataTable resultDataTable = dataTable1.Clone();
            //Temporary variables
            DataRow newDataRow;
            IEnumerable<DataRow> results;
            decimal tempCol5;
            decimal tempCol6;
            //Go through each distinct rows to gather column5 and column6 values
            foreach (var item in distinctRows)
            {
                //create a new row for the result datatable
                newDataRow = resultDataTable.NewRow();
                //select all rows in original datatable with this distinct values
                results = dataTable1.Select().Where(
                    p => p.Field<int>("Column1") == item.unique1 
                    && p.Field<int>("Column2") == item.unique2 
                    && p.Field<int>("Column3") == item.unique3 
                    && p.Field<int>("Column4") == item.unique4);
                //Preserve column1 - 4 values
                newDataRow["Column1"] = item.unique1;
                newDataRow["Column2"] = item.unique2;
                newDataRow["Column3"] = item.unique3;
                newDataRow["Column4"] = item.unique4;
                //store here the sumns of column 5 and 6
                tempCol5 = 0;
                tempCol6 = 0;
                foreach (DataRow dr in results)
                {
                    tempCol5 += (decimal)dr["Column5"];
                    tempCol6 += (decimal)dr["Column6"];
                }
                //save those sumns in the new row
                newDataRow["Column5"] = tempCol5;
                newDataRow["Column6"] = tempCol6;
                //add the row to the result dataTable
                resultDataTable.Rows.Add(newDataRow);
