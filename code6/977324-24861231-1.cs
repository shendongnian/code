    protected void SearchInvoiceButton_Click(object sender, EventArgs e)
    { 
        String WhereClause = "it.UserID==@UserID AND it.IsDeleted == false AND ((it.ClientDetail.ClientName LIKE '%' + @SearchTerm + '%') OR (it.InvoiceDetail.ItemName LIKE '%'+ @SearchTerm + '%'))";
        EntityDataSourceInvoice.Where = WhereClause;
        ViewState["InvoiceViewWhereClause"] = WhereClause;
        if (EntityDataSourceInvoice.WhereParameters["SearchTerm"] != null)
        {
            EntityDataSourceInvoice.WhereParameters["SearchTerm"].DefaultValue = SafeSearchLiteral(SearchTextBox.Text.Trim());
        }
        else
        {
            Parameter CategoryParameter = new Parameter("SearchTerm", System.Data.DbType.String, SafeSearchLiteral(SearchTextBox.Text.Trim()));
            CategoryParameter.ConvertEmptyStringToNull = false;
            EntityDataSourceInvoice.WhereParameters.Add(CategoryParameter);
        }        
        InvoiceGrid.DataBind();
        InvoiceGrid.AllowPaging = false;
        InvoiceGrid.AllowPaging = true;
    }
