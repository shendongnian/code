    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnClick_Click(object sender, EventArgs e)
    {
        lblOutput.Text = String.Empty;
        bool showModal = true;
        if(showModal)
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal('show');", true);
    }
    protected void Decision_Command(object sender, CommandEventArgs e)
    {
        lblOutput.Text = "User clicked - " + e.CommandArgument;
    }
