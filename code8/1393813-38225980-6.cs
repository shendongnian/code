    var svc = ((DataSourceProviderService)Site.GetService(typeof(DataSourceProviderService)));
    if (svc != null)
    {
        var result = svc.InvokeAddNewDataSource(this, FormStartPosition.CenterScreen);
        if(result!=null && result.DataSources.Count>0)
        {
            var type = GetTypeByName(this.Site, result.DataSources[0].TypeName);
            var properties = type.GetProperties().ToList();
            MessageBox.Show(string.Join(",", properties.Select(x => x.Name)));
        }
    }
