    private void populate DropDownMainScreen()
    {
      this.ddlemployee.DataSource = DoThis();
      this.ddlemployee.DataTextField = "employeename";
      this.ddlemployee.DataValueField = "employeeID";
      this.ddlemployee.DataBind();
    }
    
    private void DoThis()
    {
      SqlQueryBuilder = new StringBuilder();
      SqlQueryBuilder.Append = "Select employeeID, employeename from personell";
      //Actually run the query here
    }
    private void runaquery()
    {
      string employeename = this.ddlemployee.SelectedItem.DataTextField;
      string employeID = this.ddlemployee.SelectedItem.Value;
      int campaignID = ;
      Showmetheresults(RunSQLQuery, employeename, employeeID)
    }
