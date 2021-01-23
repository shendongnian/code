    var qry = context.Tbl_EmployeeDetails.Where(x => x.IsDeleted == false).ToList();   
    
    if(qry!=null)
    {                
    	drpname.ValueMember = "RecordId";
    	drpname.DisplayMember = "Name";              
    	drpname.DataSource = qry;  
        drpname.Items.Insert(0, "--Please Select--");   
        drpname.SelectedIndex = 0;                     
    }
