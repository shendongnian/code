    protected void txtDebit1_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            //NamingContainer return the container that the control sits in
            TextBox ctrl= (TextBox)row.FindControl("txtDebit1");
            ctrk.Text = "SomeValue";
        }
