        protected void ddlTestDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            if (ddl.SelectedValue == "1")
            {
                tbTestBox.Visible = true;
            }
            else if (ddl.SelectedValue == "0")
            {
                tbTestBox.Visible = false;
            }
        }
