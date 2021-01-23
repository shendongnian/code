         foreach (GridViewRow grdRow in grdMenuPermitted.Rows)
            {
                DataRow drow = dt.NewRow();
                Label lblMenuName = (Label)grdRow.FindControl("lblMenuName");
                HiddenField hdnID = (HiddenField)grdRow.FindControl("hdnID");
                drow["MenuName"] = lblMenuName.Text;//grdRow.Cells[0].Text;                
                drow["MenuID"] = hdnID.Value;
                //drow["lname"] = grdRow.Cells[3].Text;
                dt.Rows.Add(drow);
            }
