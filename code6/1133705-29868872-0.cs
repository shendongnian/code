    protected void btnSubmit_click(object sender, EventArgs e)
    {
        ContentPlaceHolder content = (ContentPlaceHolder)this.Form.FindControl("MainContent");
        foreach (Control c in content.Controls)
        {
            if (c is TextBox)
            {
                TextBox txt = (TextBox)c;
                // do something, e.g. Response.Write(txt.Text);
            } 
        }
    }
