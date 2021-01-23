    partial void TBG_KeepInTimesheets_Inserting(TBG_KeepInTimesheet entity)
    {
	    entity.CreatedBy = this.Application.User.Name;
    	entity.CreateDate = DateTime.Now;
	    entity.EmployeeID = DataWorkspace.ApplicationData.TBG_V_KeepInTimeSheet_Details.FirstOrDefault().EmployeeID;
    }
