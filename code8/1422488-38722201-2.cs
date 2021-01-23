        protected void gvwUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList DropDownListRol = (DropDownList)e.Row.FindControl("ddlRolOmschrijving");
            if (e.Row.RowType == DataControlRowType.DataRow && DropDownListRol != null)
            {
                DsFenVlaanderen.tb_rolDataTable dtRole = DsFenVlaanderen.RolTableAdapter.GetData();
                //Fill Dropdownlist
                DropDownListRol.DataSource = dtRole;
                DropDownListRol.DataValueField = dtRole.Rol_IDColumn.ColumnName;
                DropDownListRol.DataTextField = dtRole.Rol_omschrijvingColumn.ColumnName;
                DropDownListRol.DataBind();
                //Set Selected value
                DropDownListRol.Items.FindByValue(hidSelectedRole.Value).Selected = true;
            }
        }
        protected void gvwUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set hiddenfield to value of Rol_ID
            hidSelectedRole.Value = gvwUsers.DataKeys[e.NewEditIndex].Values["Rol_ID"].ToString();
        }
