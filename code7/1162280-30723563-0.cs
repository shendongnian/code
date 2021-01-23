          DataSet DSResult = new DataSet();
            DSResult.Tables.Add();
            DSResult.Tables[0].Columns.Add("ID", typeof(int));
            DSResult.Tables[0].Columns.Add("Name", typeof(string));
            DSResult.Tables[0].Rows.Add(1,"Jon");
            DSResult.Tables[0].Rows.Add(2, "Kyle");
            DSResult.Tables[0].Rows.Add(3, "Sam");
            DSResult.Tables[0].Rows.Add(4, "Peter");
            DSResult.Tables[0].Rows.Add(5, "Lily");
            DataSet DSWinners = new DataSet();
            DSWinners.Tables.Add();
            DSWinners = DSResult.Clone();
            int[] Id = new int[] { 1, 4, 5 }; //condition to match
            foreach (int val in Id)
            {
                DataRow[] Samplerow =
                  DSResult.Tables[0].AsEnumerable()
                 .Select((row, index) => new { row, index })
                 .Where(item => item.row.Field<int>("ID") == val)
                 .Select(item => item.row)
                 .ToArray();
                 DSWinners.Tables[0].ImportRow(Samplerow[0]);
            }
