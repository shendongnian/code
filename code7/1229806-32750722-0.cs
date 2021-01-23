    private GridView gvBFMats;
    protected void gvBFMats_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        gvBFMats = [your form view].Row.FindControl("gvBFMats") as GridView;
        if (e.CommandName == "Insert" && Page.IsValid)
        {  
            BFMatsSQL.Insert();
        }
    }
