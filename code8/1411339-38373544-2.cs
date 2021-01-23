    protected void btnClickMe_Click(object sender, EventArgs e)
    {
        lblTest.Text = DateTime.Now.ToString("dd MMM yyyy - HH:mm:ss");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
    }
