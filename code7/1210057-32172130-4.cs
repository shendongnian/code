        protected void grdviewContractorTypes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "edit")
                {
                    byte ContractorTypeID = Convert.ToByte(grdviewContractorTypes.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                    //HFActID.Value = ID.ToString();
                    //btnAddContractorType.Visible = false;
                    //btnUpdate.Visible = true;
                    //DataTable dt = MngContractorTypes.SelectContractorTypesByContractorTypeID(ContractorTypeID);
                    //DataRow r = dt.Rows[0];
                    //txtBoxContractorTypeName.Text = r["ContractorTypeName"].ToString();
                    Response.Write("DONE");
                }
            }
            catch (Exception)
            {
            }
        }
        protected void grdviewContractorTypes_RowEditing(object sender, GridViewEditEventArgs e)
        {
             // code to edit
        }
