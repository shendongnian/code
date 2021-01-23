    private void FetchData(ref DataTable dt)
    {
        string s_strResult = "";
        string s_strQuery = "";
        string s_strQueryType = "";
    
        try
        {                    
            dtStored = dt.DataSet.Tables["Result"];
            grdSearchResult.DataSource = dtStored;
            grdSearchResult.DataBind();
            tblSearchResult.Visible = true;            
            lblSearchResult.Text = "Total Items:" + dt.DataSet.Tables["Result"].Rows.Count;
        }
    }
