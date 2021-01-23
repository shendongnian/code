    public SoftwareSolution(string name, IEnumerable<DataSource> dataSources)
    {
        Name = name;
        this.DataSources = new ObservableCollection<DataSourceVM>(dataSource.Select(x => new DataSourceVM(x));
    }
