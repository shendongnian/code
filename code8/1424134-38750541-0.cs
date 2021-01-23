    protected void btnOK_Click(object sender, EventArgs e)
    {
        string url = String.Format("Congratulations.aspx?data={0}", txtData.Text);
        Response.Redirect(url);
    }
