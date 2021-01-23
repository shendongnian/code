    protected void gvCategory_DataBound(object sender, EventArgs e)
    {
        foreach (ListItem li in gvCategory.Items)
        {
            if(li.Text.Contains("--"))
                li.Attributes.Add("disabled", "true");
        }
    }
