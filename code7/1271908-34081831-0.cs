    datakeynames="OldEmpId,NewEmpId,EmpName"
    ...............
    ...............
    protected void RadButtonUpdateSectors_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in RadGridEmp.MasterTableView.Items)
        {
            CheckBox ChkChange = item.FindControl("ChkChange") as CheckBox;
            if (ChkChange.Checked)
            {
                string oldEmpId = item.GetDataKeyValue("OldEmpId").ToString();
                string newEmpId = item.GetDataKeyValue("NewEmpId").ToString();
                UpdateEmpId(oldEmpId, newEmpId, connString);
            }
        }
    }
