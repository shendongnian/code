    protected void AddNew_Click(object sender, EventArgs e)
            {
                    DropDownList ddlNewEmpID = grvEmployeeOnLeave.Controls[0].Controls[0].FindControl("ddlNewEmpID") as DropDownList;
                    DropDownList ddlNewLeaveTypeID = grvEmployeeOnLeave.Controls[0].Controls[0].FindControl("ddlNewLeaveTypeID") as DropDownList;
                    TextBox txtNewLeaveDate = grvEmployeeOnLeave.Controls[0].Controls[0].FindControl("txtNewLeaveDate") as TextBox;
                    TextBox txtNewNotes = grvEmployeeOnLeave.Controls[0].Controls[0].FindControl("txtNewNotes") as TextBox;
                    Data.EmployeeOnLeave obj = new Data.EmployeeOnLeave();
                    obj.LeaveDate = txtNewLeaveDate.Text;
                    obj.Notes = txtNewNotes.Text;
                    obj.EmpID = ddlNewEmpID.SelectedValue;
                    obj.LeaveTypeID = ddlNewLeaveTypeID.SelectedValue;
                    EmployeeOnLeaveService.EmployeeOnLeave_Insert(obj);
                    BindGrid();
                
            }
