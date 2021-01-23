    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("editRecord"))
                {
                    GridViewRow gvrow = GridView2.Rows[index];
                    txtID.Text = HttpUtility.HtmlDecode(gvrow.Cells[17].Text); //Pass value from Gridview's column to <asp:TextBox ID="txtID">                 
                    txtCARGO.Text = HttpUtility.HtmlDecode(gvrow.Cells[13].Text); //Pass value from Gridview's column to <asp:TextBox ID="txtCARGO">
                    lblResult.Visible = false;
                    BindEditCargo(txtCARGO.Text);
                }
            
        }
    private void BindEditCargo(string cargoValue) //Populates <asp:DropDownList id="editModalCargo">
        {
            editModalCargo.DataSource = DataAccess.GetAllCargos(); 
            editModalCargo.DataTextField = "cargo";
            editModalCargo.DataValueField = "idCARGO";
            // Bind the data to the control.
            editModalCargo.DataBind();
            // Set the default selected item, if desired.
            editModalCargo.SelectedValue = cargoValue;
        }
