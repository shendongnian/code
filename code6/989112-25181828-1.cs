    protected void btnShowModal_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "Show Modal Popup", "showmodalpopup();", true);
        string firstName = tbl.Rows[0]["firstName"].ToString();
        string lastName = tbl.Rows[0]["lastName"].ToString();
        //
        //
        // and so on
    
        lblFirstName.Text = firstName;
        lblLastName.Text = lastName;
        //
        //
        // and so on
    }
