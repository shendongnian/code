    protected void btnSave_Click(object sender, EventArgs e) // Handles Update Button Click Event
        {
            int idEMPLEADO = Convert.ToInt32(txtID.Text); //Read value from <asp:TextBox ID="txtID">   
            int idCARGO = Convert.ToInt32(editModalCargo.SelectedValue); //Read value from <asp:DropDownList id="editModalCargo">
            DataAccess.UpdateEmpleado(idEMPLEADO, idCARGO); //Update Query
            BindData(); //Refresh Gridview
        }
