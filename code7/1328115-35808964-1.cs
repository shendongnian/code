    var dt = new DataTable();
    string fileText = "1313232 , 12323232, 7676768, 8786868,1313232 , 12323232, 7676768, 8786868,1313232 , 10, 7676768, 8786868,1313232 , 12323232, 7676768, 8786868,1313232 , 12323232, 7676768, 20,1313232 , 12323232, 7676768, 8786868,1313232 , 12323232, 7676768, 8786868,1313232 , 12323232, 7676768, 8786868,";
    string[] nums = fileText.Split(',');
    //set up columns
    for (int i = 1; i < 11; i++)
    {
        dt.Columns.Add("Col" + i, typeof(int)); //add integer columns and name them
    }
    int colCount = 0;
    int[] oneRow = new int[10];
    int n, failCount = 0;
    foreach (string s in nums)
    {
        if (int.TryParse(s, out n))
        {
            oneRow[colCount] = n;
            colCount++;
        }
        else  //invalid integer
        {
            failCount++;  //you could use this value if you want to see if the file was fully valid or not.
        }
        //check if row is complete
        if (colCount == 10)
        {
            dt.Rows.Add(oneRow[0], oneRow[1], oneRow[2], oneRow[3], oneRow[4], oneRow[5], oneRow[6], oneRow[7], oneRow[8], oneRow[9]);
            colCount = 0;
            oneRow = new int[10]; //reset array
        }
    }
    if (colCount > 0) dt.Rows.Add(oneRow[0], oneRow[1], oneRow[2], oneRow[3], oneRow[4], oneRow[5], oneRow[6], oneRow[7], oneRow[8], oneRow[9]); //add final incomplete row
    //reference the DataTable as a source to the GridView and bind it.
    gvNumbers.DataSource = dt;
    gvNumbers.DataBind();
