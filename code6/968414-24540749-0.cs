     DataTable dtUsers = new DataTable();
        dtUsers = dataAccessManager.ExecuteSQLForTable("SELECT * FROM tblUser");
        UserDataGrid.DataSource = dtUsers;
        UserDataGrid.DataBind();
        //Right Below line for hide columns
        UserDataGrid.Columns[0].Visible = false;//Hide First column of the DataGrid 
        UserDataGrid.Columns[1].Visible = false;//Hide Second column of the DataGrid 
        UserDataGrid.Columns[2].Visible = false;//Hide Third column of the DataGrid 
