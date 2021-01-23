     protected void dgList_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Pager && e.Item.ItemType != ListItemType.Footer)
            {
                int count = 1;
                foreach (TableCell c in e.Item.Cells)
                {
                    bool b = Convert.ToBoolean(((DataRowView)e.Item.DataItem).Row["IsActive"]);
    
                    if (count == e.Item.Cells.Count)
                    {
                        c.Text = "<input DISABLED type=\"checkbox\" " + ((b) ? "checked" : "") + "/>";
                    }
                    DateTime dt = new DateTime();
                    if (DateTime.TryParse(c.Text, out dt))
                    {
                        c.Text = dt.ToShortDateString();
                    }
                    count++;
                }
    
                 DropDownList ddlTrailerLocation = e.Item.FindControl("ddlTrailerLoc") as DropDownList;
                 //DataSet dsTrailerLocation = DataUtils.GetAllGenSmall(Company.Current.CompanyID, "Description", "", 1, false, "Description", false, "TrailerLocationNOCODE", 0);
                 if (ddlTrailerLocation != null)
                 {
                     PopulateDDLs(ddlTrailerLocation);
                     //set the value in dropdown
                     HiddenField hdlTrailerLoc = e.Item.FindControl("hdlTrailerLoc") as HiddenField;
                     if (hdlTrailerLoc != null)
                     {
                         ddlTrailerLocation.SelectedValue = hdlTrailerLoc.Value;
                     }
                 }
            }
        }
   
  
