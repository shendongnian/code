    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using OxyPlot;
    using OxyPlot.Series;
    using OxyPlot.Axes;
    
    namespace WpfApplication2
    {
        /// <summary>
        /// Interaktionslogik für MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
    
            public PlotModel MyModel { get; private set; }
    
    
            public MainWindow()
            {
                InitializeComponent();
    
                MyModel = new PlotModel { Title = "Your Equation", LegendTitle = "Equations" };
                MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Distance" });
                MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Height" });
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                if (radioButton1.IsChecked == true)
                {
                    //MessageBox.Show("Plot Cosine");
                    graph();
    
                }
            }
    
    
            public double getValue(int x, int y)
            {
                return (10 * x * x + 11 * x * y * y + 12 * x * y);
            }
    
            //setting the values to the function
            public FunctionSeries GetFunction()
            {
                int n = 100;
                FunctionSeries serie = new FunctionSeries();
                for (int x = 0; x < n; x++)
                {
                    for (int y = 0; y < n; y++)
                    {
                        //adding the points based x,y
                        DataPoint data = new DataPoint(x, getValue(x, y));
    
                        //adding the point to the serie
                        serie.Points.Add(data);
                    }
                }
                //returning the serie
                return serie;
            }
    
    
            public void graph()
            {
                MyModel = new PlotModel { Title = "example" };
                MyModel.LegendPosition = LegendPosition.RightBottom;
                MyModel.LegendPlacement = LegendPlacement.Outside;
                MyModel.LegendOrientation = LegendOrientation.Horizontal;
    
                MyModel.Series.Add(GetFunction());
                var Yaxis = new OxyPlot.Axes.LinearAxis();
                OxyPlot.Axes.LinearAxis XAxis = new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom, Minimum = 0, Maximum = 100 };
                XAxis.Title = "X";
                Yaxis.Title = "10 * x * x + 11 * x*y*y  + 12*x*y";
                MyModel.Axes.Add(Yaxis);
                MyModel.Axes.Add(XAxis);
                this.plot.Model = MyModel;
            }
    
    
    
    
    
    
    
    
    
           
        }
    }
