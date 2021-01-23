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
