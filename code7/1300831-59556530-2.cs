    using System;
    using System.Collections.ObjectModel;
    using Infragistics.Samples.Shared.Models;
    
    namespace xamDataChartMultipleSeries
    {
        public class ChartDataCollection : ObservableCollection<ChartDataItem>
        {
            public ChartDataCollection() { }
        }
    
        public class ChartDataItem : ObservableModel
        {
            public ChartDataItem() { }
            public ChartDataItem(ChartDataItem dataPoint)
            {
                this.DateTime = dataPoint.DateTime;
                this.Series1 = dataPoint.Series1;
                this.Series2 = dataPoint.Series2;
            }
    
            private DateTime _dt;
            public DateTime DateTime
            {
                get { return _dt; }
                set { if (_dt == value) return; _dt = value; }
            }
    
            private double _series1;
            public double Series1
            {
                get { return _series1; }
                set { if (_series1 == value) return; _series1 = value; OnPropertyChanged("Series1"); }
            }
    
            private double _series2;
            public double Series2
            {
                get { return _series2; }
                set { if (_series2 == value) return; _series2 = value; OnPropertyChanged("Series2"); }
            }
    
            public new string ToString()
            {
                return base.ToString();
            }
        }
    }
