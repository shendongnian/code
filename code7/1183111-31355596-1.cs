    DataTable dt = new DataTable();
    //your sql code to fill dt
    DataRow[] drowpar = dt.Select("ParentID=" + 0);
    foreach (DataRow dr in drowpar)
    {
        menuBar.Items.Add(new MenuItem(dr["MenuName"].ToString(), 
                dr["MenuID"].ToString(), "", 
                dr["MenuLocation"].ToString()));
    }
    foreach (DataRow dr in dt.Select("ParentID >" + 0))
    {
        MenuItem mnu = new MenuItem(dr["MenuName"].ToString(), 
                       dr["MenuID"].ToString(), 
                       "", dr["MenuLocation"].ToString());
        menuBar.FindItem(dr["ParentID"].ToString()).ChildItems.Add(mnu);
    }
