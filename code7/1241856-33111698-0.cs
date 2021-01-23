    internal static ObservableCollection<string> remoteSqlServers = new ObservableCollection<string>();
    
    public MyControl()
    {
        InitializeComponent();
        GetRemoteSqlServers();
        //so on and so forth
    }
    
    public static async Task GetRemoteSqlServers()
    {
        foreach (var item in (await Task.Run(() =>
        { return new SqlEnumerationHelper().SqlEnumerateRemote(); })))
        {
            remoteSqlServers.Add(item);
        }
    }
