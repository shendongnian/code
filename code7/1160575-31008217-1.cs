    private void FillResults2()
        {
            ObjectDataSource2.SelectParameters["InvtId"].DefaultValue="11000020982";
            ObjectDataSource2.SelectParameters["IdModel"].DefaultValue = "1";
            ObjectDataSource2.SelectParameters["SiteId"].DefaultValue = "1";
    
            try
            {
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
            }
    
            if (GridView2.Rows.Count == 0)
            {
                Label2.Visible = true;
            }
