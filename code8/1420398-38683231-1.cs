            List<Tuple<string, int>> data = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("Product 1", 100),
                new Tuple<string, int>("Product 2", 200),
                new Tuple<string, int>("Product 3", 300),
                new Tuple<string, int>("Product 4", 400),
                new Tuple<string, int>("Product 5", 500),
            };
            PieSeries pieSeries = new PieSeries();
            pieSeries.FontSize = 32;
            pieSeries.TextColor = OxyColors.White;
            pieSeries.InsideLabelColor = OxyColors.White;
            pieSeries.StrokeThickness = 2;
            foreach (Tuple<string, int> t in data)
                pieSeries.Slices.Add(new PieSlice(t.Item1, t.Item2));
            MyModel.Series.Add(pieSeries);
            MyModel.Title = "Sales Per Product";
            MyModel.TitleColor = OxyColors.Teal;
            MyModel.TitleFontSize = 36;
            MyModel.Axes.Add(new LinearAxis() { Position = AxisPosition.Bottom });
            MyModel.Axes.Add(new LinearAxis() { Position = AxisPosition.Left });
            int total = data.Sum(p => p.Item2);
            TextAnnotation annotation = new TextAnnotation();
            annotation.Text = string.Format("{0:C2}", total);
            annotation.TextColor = OxyColors.Red;
            annotation.Stroke = OxyColors.Red;
            annotation.StrokeThickness = 5;
            annotation.FontSize = 36;
            annotation.TextPosition = new DataPoint(15, 90);
            MyModel.Annotations.Add(annotation);
