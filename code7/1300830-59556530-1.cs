    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.ComponentModel;
    
    namespace xamDataChartMultipleSeries
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            int points = 20;    
            List<Point> data = new List<Point>();
    
            public MainWindow()
            {
                InitializeComponent();                     
                double x = 0;
                var step = 2 * Math.PI / points;
                var now = DateTime.Now;
                xAxis.MinimumValue = now;
                xAxis.MaximumValue = now.AddDays(points);
                xAxis.Interval = new TimeSpan(0,6,0,0);    
                var next = now; 
                for (var i = 0; i < points; i++, x += step)
                {
                    next = next.AddDays(1);
                    Data.Add(new ChartDataItem() { DateTime=next, Series1 = Math.Sin(x), Series2 = Math.Cos(x) });
                }    
                if (!DesignerProperties.GetIsInDesignMode(this))
                {
                    xAxis.ItemsSource = Series1.ItemsSource = Series2.ItemsSource = Data;
                }
            }    
            // ChartDataCollection
            public ChartDataCollection Data = new ChartDataCollection();
        }
    }
