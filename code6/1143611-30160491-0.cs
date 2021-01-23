                fName += ((Label)gvrow.Cells[1].FindControl("lblFname")).Text;
                FaName  +=((Label)gvrow.Cells[2].FindControl("lblFaName").Text);
                LName  += ((Label)gvrow.Cells[3].FindControl("lblLName")).Text;
                attendance  +=((DropDownList)gvrow.Cells[4].FindControl("ddlDesignation")).SelectedItem.Text;
                remarks  += ((DropDownList)gvrow.Cells[5].FindControl("ddlRemark")).SelectedItem.Text;
