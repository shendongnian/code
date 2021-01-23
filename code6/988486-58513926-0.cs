            string[] labels = datosSeries.Select(o => o.Week).ToArray();
            float[] data = datosSeries.Select(o => o.ProfitSerie).ToArray();
            chart2.Series.Add("Series1");
            chart2.Series[0].Points.DataBindXY(labels, data);
            chart2.Series[0].ChartType = SeriesChartType.Pie;
            chart2.Series[0]["PieLabelStyle"] = "Outside";
            chart2.Series[0].BorderWidth = 1;
            chart2.Series[0].BorderColor = System.Drawing.Color.FromArgb(26, 59, 105);
            chart2.Series[0].Label = "#PERCENT{P2}";
            chart2.Legends.Add(new Legend("Default"));
            // Add Color column
            LegendCellColumn firstColumn = new LegendCellColumn();
            firstColumn.ColumnType = LegendCellColumnType.SeriesSymbol;
            firstColumn.HeaderText = "";
            chart2.Legends["Default"].CellColumns.Add(firstColumn);
            // Add name cell column
            LegendCellColumn percentColumn = new LegendCellColumn();
            percentColumn.Text = "#VALX";
            percentColumn.HeaderText = "Tipo de Gastos";
            percentColumn.Name = "nameColumn";
            chart2.Legends["Default"].CellColumns.Add(percentColumn);
            //Format the legend
            chart2.Legends["Default"].LegendStyle = LegendStyle.Table;
            chart2.Legends["Default"].TableStyle = LegendTableStyle.Tall;
            chart2.Legends["Default"].DockedToChartArea = "ChartArea1";
            chart2.Legends["Default"].IsDockedInsideChartArea = false;
            chart2.Legends["Default"].Docking = Docking.Bottom;
