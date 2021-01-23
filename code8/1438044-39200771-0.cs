    private void btnLoad_Click(object sender, EventArgs e)
    {
        GenerateChart(this.DemoChart, LoadData());
    }
    /// <summary>
    /// Load data from Azure Table
    /// </summary>
    /// <returns></returns>
    private IList<MetricEntity> LoadData()
    {
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
        CloudConfigurationManager.GetSetting("BruceChenStorageConnectionString"));
        CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
        CloudTable cloudTable = tableClient.GetTableReference("TelephonyIssueLog");
        cloudTable.CreateIfNotExists();
        TableQuery<MetricEntity> query = new TableQuery<MetricEntity>()
            .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Issues"));
        return cloudTable.ExecuteQuery(query).ToList();
    }
    /// <summary>
    /// Generate the column chart with the specified data source
    /// </summary>
    /// <param name="chart"></param>
    /// <param name="dataItems"></param>
    private void GenerateChart(Chart chart, IEnumerable<MetricEntity> dataItems)
    {
        chart.Series.Clear();
        chart.Titles.Add(
            new Title("Demo Chart for loading data from Azure Table"));
        List<string> xValues = new List<string>() { "MetricA", "MetricB", "MetricC" };
        foreach (var item in dataItems)
        {
            Series series = new Series() { Name = item.UserName };
            series.ChartType = SeriesChartType.Column;
            series.Points.DataBindXY(xValues, new List<int>() {
              item.MetricA,
              item.MetricB,
              item.MetricC});
            chart.Series.Add(series);
        }
    }
