         public MainWindow()
        {
            InitializeComponent();
            canvas.Children.Clear();
            Point[] points = new Point[4]
            {
                new Point(0,  0),
                new Point(300 , 300),
                new Point(400, 500),
                new Point(700, 100 )
            };
            DrawLine(points);
            //DrawLine2(points);
        }
        private void DrawLine(Point[] points)
        {
            int i;
            int count = points.Length;
            for (i = 0; i < count - 1; i++)
            {
                Line myline = new Line();
                myline.Stroke = Brushes.Red;
                myline.X1 = points[i].X;
                myline.Y1 = points[i].Y;
                myline.X2 = points[i + 1].X;
                myline.Y2 = points[i + 1].Y;
                canvas.Children.Add(myline);
            }
        }
        private void DrawLine2(Point[] points)
        {
            Polyline line = new Polyline();
            PointCollection collection = new PointCollection();
            foreach(Point p in points)
            {
                collection.Add(p);
            }
            line.Points = collection;
            line.Stroke = new SolidColorBrush(Colors.Black);
            line.StrokeThickness = 1;
            canvas.Children.Add(line);
        }
