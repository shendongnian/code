    using WinRTXamlToolkit.Controls.DataVisualization.Charting;
    public class FinancialStuff
    {
        public string Name { get; set; }
        public int Amount { get; set; }
    }
     
    public MainPage()
    {
        this.InitializeComponent();
        this.Loaded += MainPage_Loaded;
    }
     
    void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        LoadChartContents();
    }
     
    private void LoadChartContents()
    {
        Random rand = new Random();
        List<FinancialStuff> financialStuffList = new List<FinancialStuff>();
        financialStuffList.Add(new FinancialStuff() { Name = "MSFT", Amount = rand.Next(0, 200) });
        financialStuffList.Add(new FinancialStuff() { Name = "AAPL", Amount = rand.Next(0, 200) });
        financialStuffList.Add(new FinancialStuff() { Name = "GOOG", Amount = rand.Next(0, 200) });
        financialStuffList.Add(new FinancialStuff() { Name = "BBRY", Amount = rand.Next(0, 200) });
        (PieChart.Series[0] as PieSeries).ItemsSource = financialStuffList;
        (ColumnChart.Series[0] as ColumnSeries).ItemsSource = financialStuffList;
        (LineChart.Series[0] as LineSeries).ItemsSource = financialStuffList;
    }
     
