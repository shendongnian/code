    protected void ValidateProductCode(object source, ServerValidateEventArgs args)
    {
        args.IsValid = ValidateProductCode(ddlSiteId.SelectedValue, txtProductCode.Text);
    }
    
    // This method would be called both from the client and server side
    [WebMethod]
    public static bool ValidateProductCode(string siteId, string productCode)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(GetConnection.GetConnectionString()))
            using (SqlCommand sqlComm = new SqlCommand("PL_ProductCodes_FillScreen", conn))
            {
                sqlComm.Parameters.AddWithValue("@SiteID", siteId);
                sqlComm.Parameters.AddWithValue("@ProductCode", productCode);
                sqlComm.Parameters.AddWithValue("@IsOntext", 1);
    
                sqlComm.CommandType = CommandType.StoredProcedure;
    
                SqlDataAdapter da = new SqlDataAdapter(sqlComm);
                DataSet ds = new DataSet();
                da.Fill(ds);
    
                return ds.Tables[0].Rows.Count != 0;
            }
        }
        catch (SqlException ex)
        {
            ExceptionHandling.SQLException(ex, constPageID, constIsSiteSpecific);
        }
    
        return false;
    }
