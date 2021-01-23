    protected void gvAgreement_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string AgreementId = gvAgreement.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvProducts = e.Row.FindControl("gvProducts") as GridView;
                if(gvProducts != null)
                {
                      gvProducts.DataSource = [some query or data source here]
                      gvProducts.DataBind();
                }
                int count = gvProducts.Rows.Count;
                Session["countgrid"] = count;
            }
    }
