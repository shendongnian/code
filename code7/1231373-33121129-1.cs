    using System.Collections.ObjectModel;
    using System.Windows;
    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    
    namespace OxyPlot_TEST
    {
        /// <summary>
        /// Interaction logic for Window2.xaml
        /// </summary>
        public partial class Window2 : Window
        {
            public Window2()
            {
                InitializeComponent();
    
                // Create some data
                this.Items = new Collection<Item>
                                {
                                    new Item {Label = "Apples", Value1 = 37, Value2 = 12, Value3 = 19},
                                    new Item {Label = "Pears", Value1 = 7, Value2 = 21, Value3 = 9},
                                    new Item {Label = "Bananas", Value1 = 23, Value2 = 2, Value3 = 29}
                                };
    
                // Create the plot model
                var tmp = new PlotModel { Title = "Column series", LegendPlacement = LegendPlacement.Outside, LegendPosition = LegendPosition.RightTop, LegendOrientation = LegendOrientation.Vertical };
    
                // Add the axes, note that MinimumPadding and AbsoluteMinimum should be set on the value axis.
                tmp.Axes.Add(new CategoryAxis { ItemsSource = this.Items, LabelField = "Label" });
                tmp.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MinimumPadding = 0, AbsoluteMinimum = 0 });
    
                ColumnSeries bar = new ColumnSeries
                {
                    FillColor = OxyPlot.OxyColors.Yellow,
                    ValueField = "Value1",
                    Title = "Value1",
                    ItemsSource = Items
                };
                ColumnSeries bar1 = new ColumnSeries
                {
                    FillColor = OxyPlot.OxyColors.Green,
                    ValueField = "Value1",
                    Title = "Value1",
                    ItemsSource = Items
                };
                ColumnSeries bar2 = new ColumnSeries
                {
                    FillColor = OxyPlot.OxyColors.Red,
                    ValueField = "Value1",
                    Title = "Value1",
                    ItemsSource = Items
                };
                tmp.Series.Add(bar);
                tmp.Series.Add(bar1);
                tmp.Series.Add(bar2);
    
                this.Model1 = tmp;
                this.DataContext = this;
            }
    
            public Collection<Item> Items { get; set; }
    
            public PlotModel Model1 { get; set; }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                Items.RemoveAt(0);
                Model1.InvalidatePlot(true);
            }
        }
    
        public class Item
        {
            public string Label { get; set; }
            public double Value1 { get; set; }
            public double Value2 { get; set; }
            public double Value3 { get; set; }
        }
    }
