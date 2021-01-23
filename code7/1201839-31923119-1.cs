    List<string> WareHouseStatus = new List<string>() { "1", "11", "111" };
    List<string> Gulf_IT_Barcode = new List<string>() { "2", "22", "222" };
    List<string> Item_Original_SNO = new List<string>() { "3", "33", "333" };
    
    System.Data.DataTable NewTempletLaptop_Excel = new System.Data.DataTable();
    NewTempletLaptop_Excel.Columns.Add("WareHouseStatus", typeof(string));
    NewTempletLaptop_Excel.Columns.Add("Gulf_IT_Barcode", typeof(string));
    NewTempletLaptop_Excel.Columns.Add("Item_Original_SNO", typeof(string));
    
    int row = 0; // row index in data
    foreach (var item in WareHouseStatus)
    {
        // create new row, do it only first time
        NewTempletLaptop_Excel.Rows.Add(NewTempletLaptop_Excel.NewRow());
        // set value to the appropriate cell
        NewTempletLaptop_Excel.Rows[row]["WareHouseStatus"] = item;
        row++;
    }
    
    row = 0;
    foreach (var item in Gulf_IT_Barcode)
    {
        // set value to the appropriate cell
        NewTempletLaptop_Excel.Rows[row]["Gulf_IT_Barcode"] = item;
        row++;
    }
    
    row = 0;
    foreach (var item in Item_Original_SNO)
    {
        // set value to the appropriate cell
        NewTempletLaptop_Excel.Rows[row]["Item_Original_SNO"] = item;
        row++;
    }
