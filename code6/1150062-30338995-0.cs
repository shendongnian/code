    protected void gvAttorneys_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditAttorney")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvAttorneys.Rows[index];
                HiddenField hdAttorneyID = row.FindControl("hdAttorneyID") as HiddenField;
                string attorneyID = hdAttorneyID.Value;
                int intAttorneyID = 0;
                if (int.TryParse(attorneyID, out intAttorneyID))
                {
                    LoadAttorneyPopup(intAttorneyID,index);
                }
            }
        }
    
        private void LoadAttorneyPopup(int intAttorneyID,int rowIndex)
        {
            ResetAttorneyPopup();
    
            hdAttorneyID_Popup.Value = intAttorneyID.ToString();
            if (intAttorneyID > 0)
            {
                PopulateAttorneyPopup(rowIndex);
            }
    
            popup.Show();
        }
    
        private void PopulateAttorneyPopup(int rowIndex)
        {
                GridViewRow row = gvAttorneys.Rows[rowIndex];
                txtAttorneyName.Text = row.Cells[0].Text;
                txtStartDate.Text = row.Cells[1].Text;
                cblCLECompleted.Text = row.Cells[2].Text;
                txtLast4ofSS.Text = row.Cells[3].Text;
        }
