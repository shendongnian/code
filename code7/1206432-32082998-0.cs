    for (int column = 0; column < seriesHeaders.Length; column++) {
        var header = seriesHeaders[column];
        var series = chart.Series[header] = new Series(header) {
            BorderWidth = 2,
            ChartArea = DataTable.TableName,
            ChartType = SeriesChartType.Line,
            Color = legendColors[header],
            Enabled = true,
            Font = new Font("Lucida Sans Unicode", 6f),
            XValueMember = "Week",
            YValueMembers = header
        };
        series.EmptyPointStyle.Color = legendColors[header];
        series.EmptyPointStyle.BorderWidth = 2;
        DataTable.Rows
            .OfType<DataRow>()
            .Select(r => {
                var value = (double)r[header];
                return new {
                    isEmpty = Double.IsNaN(value),
                    yValue = new double[] { value },
                    xValue = DateTime.Parse(r["Week"].ToString()).ToOADate()
                };
            })
            .ToList()
            .ForEach(dp => {
                var dataPoint = new DataPoint() {
                    IsEmpty = dp.isEmpty,
                    YValues = dp.yValue,
                    XValue = dp.xValue
                };
                series.Points.Add(dataPoint);
            });
    }
