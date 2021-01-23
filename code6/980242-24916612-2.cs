    protected void ValidateProductCode(object source, ServerValidateEventArgs args)
    {
        if (string.IsNullOrEmpty(args.Value))
        {
            args.IsValid = true;
        }
        else
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnection.GetConnectionString()))
                using (SqlCommand sqlComm = new SqlCommand("PL_ProductCodes_FillScreen", conn))
                {
                    sqlComm.Parameters.AddWithValue("@SiteID", ddlSiteId.SelectedValue);
                    sqlComm.Parameters.AddWithValue("@ProductCode", txtProductCode.Text);
                    sqlComm.Parameters.AddWithValue("@IsOntext", 1);
                    
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    
                    SqlDataAdapter da = new SqlDataAdapter(sqlComm);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    
                    args.IsValid = ds.Tables[0].Rows.Count != 0;
                }
            }
            catch (SqlException ex)
            {
                ExceptionHandling.SQLException(ex, constPageID, constIsSiteSpecific);
                args.IsValid = false;
            }
        }
    }
