    protected void DetailsGrid_ColumnSorted(object sender, Infragistics.Web.UI.GridControls.SortingEventArgs e)
    {
        var dataSource = SortingField.Value;
        List<Details> result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Details>>(dataSource);
        DetailsGrid.DataSource = result;
        DetailsGrid.DataBind();
    }
