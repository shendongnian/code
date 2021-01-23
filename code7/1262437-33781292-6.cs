        protected void GridView1_RowDataBound(object sender,  GridViewRowEventArgs e)
        {
            try
            {
                DropDownList ddl1 = (e.Row.FindControl("ddlFirstEntry") as DropDownList);
                Label lbl1 = (e.Row.FindControl("lblFirstEntry") as Label);
                DropDownList ddl2 = (e.Row.FindControl("ddlSecondEntry") as DropDownList);
                Label lbl2 = (e.Row.FindControl("lblSecondEntry") as Label);                
                ddl1.Items.Clear();
                ddl1.AppendDataBoundItems = true;
                ddl1.Items.Add(new ListItem("-Select-", "-1"));
                ddl1.DataSource = ViewState["ddl1datasourse"];
                ddl1.DataTextField = "Value";
                ddl1.DataValueField = "Id";
                ddl1.DataBind();
                if (ddl1.SelectedValue != string.Empty && lbl1.Text != null)
                    ddl1.SelectedValue = lbl1.Text.Trim();
                else
                    ddl1.SelectedValue = "-1";
                ddl2.Items.Clear();
                ddl2.AppendDataBoundItems = true;
                ddl2.Items.Add(new ListItem("-Select-", "-1"));
                ddl2.DataSource = ViewState["ddl2datasourse"];
                ddl2.DataTextField = "Value";
                ddl2.DataValueField = "Id";
                ddl2.DataBind();
                if (ddl2.SelectedValue != string.Empty && lbl2.Text != null)
                    ddl2.SelectedValue = lbl2.Text.Trim();
                else
                    ddl2.SelectedValue = "-1";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
