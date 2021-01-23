    public List<IReports> ReportsTable { get; set; }
    
    public MainWindow()
    {
        InitializeComponent();
        ReportsTable = new List<IReports>() {
            new Students() { Name = "Student 1" },
            new Students() { Name = "Student 2" },
            new Classes() { ClassName="CS 101", StudentName = "Student 3" },
            new Cars() { CarType = "Truck", Mileage=12345, StudentName = "Student 4" }
        };
        this.DataContext = this;
    }
