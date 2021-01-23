    public List<ChartItem> chartItems;
    public Form1()
    {
        InitializeComponent();
        chart1.Series[0].Points.Clear();
        chartItems = new List<ChartItem>();
        chartItems.Add(new ChartItem(DateTime.Today, 1);
        chartItems.Add(new ChartItem(DateTime.Today.AddMinutes(15), 2); // "Or something"
        ...
        chart1.Series[0].Points.DataBind(chartItems, "Time", "Value", "");
        chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm";
    }
