    protected void ListView1_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        List<TableDetails> lstDetails = Session["ListView1Data"] as List<TableDetails>;
            
        if (lstDetails.Count >= e.ItemIndex + 1)
        {
            var tableDetail = lstDetails[e.ItemIndex];
            tableDetail.FirstName = e.NewValues["FirstName"].ToString();
            tableDetail.LastName = e.NewValues["LastName"].ToString();
            tableDetail.Column3 = e.NewValues["Column3"].ToString();
            tableDetail.Column4 = Convert.ToDateTime(e.NewValues["Column4"]);             
            ListView1.EditIndex = -1;
            Session["ListView1Data"] = lstDetails;
            BindData();
        }
    }
