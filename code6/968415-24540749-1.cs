     DataTable dtUsers = new DataTable();
        dtUsers = dataAccessManager.ExecuteSQLForTable("SELECT * FROM tblUser");
        UserDataGrid.DataSource = dtUsers;
        UserDataGrid.DataBind();
        //Right Below line for Remove columns
    
        UserDataGrid.Columns[0].Remove(); //Remove First column of the DataGrid 
        UserDataGrid.Columns[1].Remove(); //Remove Second column of the DataGrid 
        UserDataGrid.Columns[2].Remove(); //Remove Third column of the DataGrid 
