     protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {
            SearchHint = txtName.Text.Split('[')[0].ToString().Trim();
            WebUtility.SetCookie(Response, "gslCountry", WebUtility.GetDropDownListValue(ddlCountry, String.Empty), false);
            WebUtility.SetCookie(Response, "gslState", WebUtility.GetDropDownListValue(ddlState, String.Empty), false);
            WebUtility.SetCookie(Response, "gslName", txtName.Text, false);
            WebUtility.SetCookie(Response, "gslCity", txtCity.Text, false);
            BindGrid();
        }
        catch (Exception ex)
        {
        }
    }
