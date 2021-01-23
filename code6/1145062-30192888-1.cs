        protected void grvSupplierStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow && grvSupplierStatus.EditIndex == e.Row.RowIndex)
                {
                    DropDownList ddlSupStatus = (DropDownList)e.Row.FindControl("ddlSupstatus");
                    Label lblsuppstatus = (Label)e.Row.FindControl("lblsuppStatus");                    
                    DataSet ds = new DataSet();
                    ds = GetYesNoValue("suppStatus");
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    ddlSupStatus .DataSource = dt;
                    ddlSupStatus .DataTextField = "suppStatus";
                    ddlSupStatus .DataValueField = "suppStatus";
                    ddlSupStatus .DataBind();
                    ddlSupStatus.Items.FindByValue(lblsuppstatus.Text).Selected = true;
                }
            }
            catch (Exception ex)
            {                
            }
            
        }  
