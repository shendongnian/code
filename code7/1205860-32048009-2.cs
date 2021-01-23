    protected void grvEmployeeOnLeave_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    DropDownList ddlNewEmpID = (DropDownList)e.Row.FindControl("ddlNewEmpID");
                    ddlNewEmpID.DataSource = EmployeeService.Employee_Working();
    
                    ddlNewEmpID.DataBind();
                    DropDownList ddlNewLeaveTypeID = (DropDownList)e.Row.FindControl("ddlNewLeaveTypeID");
                    ddlNewLeaveTypeID.DataSource = LeaveTypeService.LeaveType_GetByAll2();
    
                    ddlNewLeaveTypeID.DataBind();
                    
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {...................................................
    }
