    public partial class UserControl1 : UserControl
    {
        public PlotModel Model { get; set; }
    
        public UserControl1()
        {
            InitializeComponent();
    
            Model = new PlotModel();
            Model.LegendBorderThickness = 0;
            Model.LegendOrientation = LegendOrientation.Horizontal;
            Model.LegendPlacement = LegendPlacement.Outside;
            Model.LegendPosition = LegendPosition.BottomCenter;
            Model.Title = "Simple model";
            var categoryAxis1 = new CategoryAxis();
            categoryAxis1.MinorStep = 1;
            categoryAxis1.ActualLabels.Add("Category A");
            categoryAxis1.ActualLabels.Add("Category B");
            categoryAxis1.ActualLabels.Add("Category C");
            categoryAxis1.ActualLabels.Add("Category D");
            Model.Axes.Add(categoryAxis1);
            var linearAxis1 = new LinearAxis();
            linearAxis1.AbsoluteMinimum = 0;
            linearAxis1.MaximumPadding = 0.06;
            linearAxis1.MinimumPadding = 0;
            Model.Axes.Add(linearAxis1);
            var columnSeries1 = new ColumnSeries();
            columnSeries1.StrokeThickness = 1;
            columnSeries1.Title = "Series 1";
            columnSeries1.Items.Add(new ColumnItem(25, -1));
            columnSeries1.Items.Add(new ColumnItem(137, -1));
            columnSeries1.Items.Add(new ColumnItem(18, -1));
            columnSeries1.Items.Add(new ColumnItem(40, -1));
            Model.Series.Add(columnSeries1);
            var columnSeries2 = new ColumnSeries();
            columnSeries2.StrokeThickness = 1;
            columnSeries2.Title = "Series 2";
            columnSeries2.Items.Add(new ColumnItem(12, -1));
            columnSeries2.Items.Add(new ColumnItem(14, -1));
            columnSeries2.Items.Add(new ColumnItem(120, -1));
            columnSeries2.Items.Add(new ColumnItem(26, -1));
            Model.Series.Add(columnSeries2);
    
            DataContext = this;
        }
    }
