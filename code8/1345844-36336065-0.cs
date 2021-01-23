    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
    
        var app = new MainWindow();
        var dbContext = new MyEntities();
        var context = new MyViewModel(dbContext);
    
        app.DataContext = context;
        app.Show();
    }
