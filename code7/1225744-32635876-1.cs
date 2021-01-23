    var qry = context.Tbl_EmployeeDetails.Where(x => x.IsDeleted == false).ToList();   
    qry.Insert(0, "--Please Select--");
    if(qry!=null)
    {                
    	drpname.ValueMember = "RecordId";
    	drpname.DisplayMember = "Name";              
    	drpname.DataSource = qry; 
        drpname.SelectedIndex = 0; 
    }
