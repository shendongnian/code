    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e) 
    {
         using(SqlConnection conn = new SqlConnection(.....))
         using(SqlDataAdapter da = new SqlDataAdapter())
         {
            string cmdText = @"SELECT SName,SID FROM state WHERE CID=@country";
            da.SelectCommand = new SqlCommand(cmdText, conn);
            da.SelectCommand.Parameters.Add("@country", SqlDbType.Int).Value = ddlCountry.SelectedValue;
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlState.DataSource = dt;
            ddlState.DataTextField = "SName";
            ddlState.DataValueField = "SID";
            ddlState.DataBind();
        }
     }
