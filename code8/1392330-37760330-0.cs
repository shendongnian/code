    //Loop through all the rows in gridview
    foreach (GridViewRow grv in grdEmp.Rows)
    {
    //Finiding checkbox control in gridview for particular row
    CheckBox chk = (CheckBox)grv.FindControl("chkDel");
    
    if (chk.Checked)
    {
    //get EmpId from DatakeyNames from gridview
    int empid = Convert.ToInt32(grdEmp.DataKeys[grv.RowIndex].Value);
    
    cmd = new SqlCommand("Update_Sp", con); //Put ur Inline query here
    cmd.Parameters.Add("@Username", SqlDbType.Int).Value = Username; //use as per ur requirments
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.ExecuteNonQuery();
    }
    }
    grdEmp.EditIndex = -1; 
    BindEmpGrid();
