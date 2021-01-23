    IList<DataPoint> _points;
    public IList<DataPoint> Points { get{return _points;}; private set{ _points = value; OnPropertyChanged("Points");} }
    
            private void OnPropertyChanged(string p)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
    public void Second()
        {
            this.Points.Clear();
            this.Title = "Test";
    
            this.Points = new List<DataPoint>();
    
            for (int i = 0; i <= 800; i++)
            {
                double x = (Math.PI * i) / 400;
                double y = Math.Cos(x);
                DataPoint p = new DataPoint(x, 0.5);
                Points.Add(p);
            }
            /* suggested change */
            OnPropertyChanged("Points");
        }
