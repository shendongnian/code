    if (cboAssignTo != null)
     {
             GetUsers();
             cboAssignTo.DataSource = GetActiveUsers(dstAuthUsrList).Tables[0];
             cboAssignTo.DataBind(); // Add this statement
             ListItem lstItm = new ListItem("New", "");
             cboAssignTo.Items.Insert(0, lstItm);
    }
