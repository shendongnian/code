        protected void grv_SelectedIndexChanged(object sender, EventArgs e)
            {
                String groupedErrorID = "";
                GridViewRow row = (((YourControl)sender).Parent.Parent as GridViewRow);        
                groupedErrorID = row.Cells[1].Text.ToString();
                lblID.Text = groupedErrorID; //for testing purposes
            }
