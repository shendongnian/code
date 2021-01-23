    private void ExportToExcel()
    {
        //First fetch all records from grid to dataset
        DataSet dset = new DataSet();
        dset.Tables.Add();
        //First Add Columns from gridview to excel
        for (int i = 0; i < gridView.Columns.Count; i++) //GridView is id of gridview
        {
            dset.Tables[0].Columns.Add(gridView.Columns[i].HeaderText);
        }
        //add rows to the table 
        System.Data.DataRow dr1;
        for (int i = 0; i < gridView.Rows.Count; i++)
        {
            dr1 = dset.Tables[0].NewRow(); //For Example There are only 3 columns into gridview
            System.Web.UI.WebControls.Label lblCCName = 
              (System.Web.UI.WebControls.Label)gridView.Rows[i].Cells[0].FindControl("lblCCName");
            System.Web.UI.WebControls.Label lblItemName = 
              (System.Web.UI.WebControls.Label)gridView.Rows[i].Cells[0].FindControl("lblItemName");
            System.Web.UI.WebControls.Label lblItemCode = 
              (System.Web.UI.WebControls.Label)gridView.Rows[i].Cells[0].FindControl("lblItemCode");
            dr1[0] = lblCCName.Text.ToString();
            dr1[1] = lblItemName.Text.ToString();
            dr1[2] = lblItemCode.Text.ToString(); 
            dset.Tables[0].Rows.Add(dr1); 
        }
        //below code is export dset to excel
        ApplicationClass excel = new ApplicationClass();
        Workbook wBook;
        Worksheet wSheet; 
        wBook = excel.Workbooks.Add(System.Reflection.Missing.Value);
        wSheet = (Worksheet)wBook.ActiveSheet;
        System.Data.DataTable dt = dset.Tables[0];
        System.Data.DataColumn dc = new DataColumn();
        int colIndex = 0;
        int rowIndex = 4;
        foreach (DataColumn dcol in dt.Columns)
        {
            colIndex = colIndex + 1;
            excel.Cells[5, colIndex] = dcol.ColumnName;
        }
        foreach (DataRow drow in dt.Rows) 
        {
            rowIndex = rowIndex + 1;
            colIndex = 0;
            foreach (DataColumn dcol in dt.Columns)
            {
                colIndex = colIndex + 1;
                excel.Cells[rowIndex + 1, colIndex] = drow[dcol.ColumnName];
            }
        }
        wSheet.Columns.AutoFit();
        // Server File Path Where you want to save excel file.
        String strFileName = Server.MapPath("~\\Images\\StockStatement.xls");
        Boolean blnFileOpen = false;
        try
        {
            System.IO.FileStream fileTemp = File.OpenWrite(strFileName);
            fileTemp.Close();
        }
        catch
        {
            blnFileOpen = false;
        }
        if (System.IO.File.Exists(strFileName))
        //It checks if file exists then it delete that file.
        {
            System.IO.File.Delete(strFileName);
        }  
    }
