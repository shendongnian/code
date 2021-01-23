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
                                    new Item {Label = "Apples", Value1 = 37},
                                    new Item {Label = "Pears", Value1 = 7},
                                    new Item {Label = "Bananas", Value1 = 23}
                                };
    
                // Create the plot model
                var tmp = new PlotModel { Title = "Column series", LegendPlacement = LegendPlacement.Outside, LegendPosition = LegendPosition.RightTop, LegendOrientation = LegendOrientation.Vertical };
    
                // Add the axes, note that MinimumPadding and AbsoluteMinimum should be set on the value axis.
                tmp.Axes.Add(new CategoryAxis { ItemsSource = this.Items, LabelField = "Label" });
                tmp.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MinimumPadding = 0, AbsoluteMinimum = 0 });
    
                ColumnSeries bar = new ColumnSeries
                {
                    FillColor = OxyPlot.OxyColors.Black,
                    ValueField = "Value1",
                    Title = "Value1",
                    ItemsSource = Items
                };
                tmp.Series.Add(bar);
    
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
    
            private void button2_Click(object sender, RoutedEventArgs e)
            {
                Items.Add(new Item()
                {
                    Label = "Strawberrys", Value1 = 55
                });
                Model1.InvalidatePlot(true);
            }
        }
    
        public class Item
        {
            public string Label { get; set; }
            public double Value1 { get; set; }
        }
    }
