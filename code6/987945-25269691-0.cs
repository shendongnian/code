    DataTable mydata = new DataTable();
            // Define the columns and their names
            mydata.Columns.Add("Series Labels", typeof(string));
            mydata.Columns.Add("63", typeof(int));
            mydata.Columns.Add("125", typeof(int));
            mydata.Columns.Add("250", typeof(int));
            mydata.Columns.Add("500", typeof(int));
            mydata.Columns.Add("1k", typeof(int));
            mydata.Columns.Add("2k", typeof(int));
            mydata.Columns.Add("4k", typeof(int));
            // Add the rows of data
            mydata.Rows.Add(new Object[] { "RC 50", 70, 65, 60, 55, 50, 45, 40 });
            mydata.Rows.Add(new Object[] { "RC 45", 65, 60, 55, 50, 45, 40, 35 });
            mydata.Rows.Add(new Object[] { "RC 40", 60, 55, 50, 45, 40, 35, 30 });
            mydata.Rows.Add(new Object[] { "RC 35", 55, 50, 45, 40, 35, 30, 25 });
            mydata.Rows.Add(new Object[] { "RC 30", 50, 45, 40, 35, 30, 25, 20 });
            mydata.Rows.Add(new Object[] { "RC 25", 45, 40, 35, 30, 25, 20, 15 });
            mydata.Rows.Add(new Object[] { "User Input", userInput[0], userInput[1], userInput[2], userInput[3], userInput[4], userInput[5], userInput[6] });
            mydata.Rows.Add(new Object[] { "Rumble Limit", speechInterferenceLine + 25, speechInterferenceLine + 20, speechInterferenceLine + 15, speechInterferenceLine + 10, null, null, null });
            mydata.Rows.Add(new Object[] { "Hissy Limit", null, null, null, null, speechInterferenceLine + 3, speechInterferenceLine + -2, speechInterferenceLine - 7 });
            mydata.Rows.Add(new Object[] { "Reference Line", speechInterferenceLine + 20, speechInterferenceLine + 15, speechInterferenceLine + 10, speechInterferenceLine + 5, speechInterferenceLine, speechInterferenceLine - 5, speechInterferenceLine - 10 });
