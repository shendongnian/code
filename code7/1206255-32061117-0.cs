    internal void BuildChart(DataTable DataTable) {
        var xAxisTitle = DataTable.Columns[1].ExtendedProperties["Type"].ToString();
        var yAxisTitle = DataTable.Columns[0].ExtendedProperties["Type"].ToString();
    
        chart = new Chart() {
            AntiAliasing = AntiAliasingStyles.All,
            TextAntiAliasingQuality = TextAntiAliasingQuality.High,
            Width = 1800,
            Height = 500,
            Enabled = true,
            ForeColor = Color.SaddleBrown
        };
    
        #region build chart area
        var chartArea = new ChartArea() {
            BackColor = Color.White,
            Name = DataTable.TableName,
    
            AxisY = new Axis() {
                Enabled = AxisEnabled.True,
                Title = yAxisTitle,
                LineColor = Color.DarkBlue,
                MajorTickMark = new TickMark() {
                    Enabled = true,
                    LineColor = Color.DarkGreen,
                },
                MinorTickMark = new TickMark() {
                    Enabled = true,
                    LineColor = Color.Green,
                },
                LabelStyle = new LabelStyle() {
                    Enabled = true,
                    ForeColor = Color.Red,
                    IsEndLabelVisible = true,
                    Font = new Font("Calibri", 4, FontStyle.Regular)
                },
                MajorGrid = new Grid() {
                    Enabled = true,
                    LineColor = Color.LightGray,
                    LineWidth = 1
                },
            },
    
            AxisX = new Axis() {
                Enabled = AxisEnabled.True,
                Title = xAxisTitle,
                LineColor = Color.DarkBlue,
                MajorTickMark = new TickMark() {
                    Enabled = true,
                    LineColor = Color.Red,
                },
                MinorTickMark = new TickMark() {
                    Enabled = true,
                    LineColor = Color.DarkGreen,
                },
                LabelStyle = new LabelStyle() {
                    Enabled = true,
                    ForeColor = Color.Blue,
                    IsEndLabelVisible = true,
                    Font = new Font("Calibri", 4, FontStyle.Regular)
                },
                MajorGrid = new Grid() {
                    Enabled = true,
                    LineColor = Color.DarkGray,
                    LineWidth = 1
                },
            },
        };
    
        chartArea.AxisX.Enabled = AxisEnabled.True;
        chartArea.AxisY.Enabled = AxisEnabled.True;
        #endregion
    
        chart.ChartAreas.Add(chartArea);
    
        var seriesHeaders = DataTable.Columns
            .OfType<DataColumn>()
            .Skip(1)
            .Select(c => c.ColumnName)
            .ToArray();
    
        chart.Legends.Add(new Legend(DataTable.TableName) {
            Enabled = true
        });
    
        for (int column = 0; column < seriesHeaders.Length; column++) {
            var header = seriesHeaders[column];
    
            var series = chart.Series[header] = new Series(header) {
                BorderWidth = 2,
                ChartArea = DataTable.TableName,
                ChartType = SeriesChartType.FastLine,
                Color = legendColors[header],
                Enabled = true,
                Font = new Font("Lucida Sans Unicode", 6f),
                XValueMember = "Week",
                YValueMembers = header
            };
    
            series.EmptyPointStyle.MarkerColor = legendColors[header];
        }
    
        chart.DataSource = DataTable;
        chart.DataBind();
    }
