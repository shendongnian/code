            object[,] data1 = new object[Dt.Rows.Count, 2];
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                data1[i, 0] = Dt.Rows[i]["IncDate"];
                data1[i, 1] = Dt.Rows[i]["IncCost"];
            }
            object[,] data2 = new object[Dt2.Rows.Count, 2];
            for (int i = 0; i < Dt2.Rows.Count; i++)
            {
                data2[i, 0] = Dt2.Rows[i]["ExpDate"];
                data2[i, 1] = Dt2.Rows[i]["ExpCost"];
            }
            Highcharts chart = new Highcharts("graph")
               .SetTitle(new Title { Text = "Incoming Stats" })
               .SetXAxis(new XAxis { Type = AxisTypes.Datetime })
               .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Amount Incoming" } })
               .SetSeries(new[]
                 {
                        new Series { Name = "inc", Data = new Data(data1) },
                        new Series { Name = "exp", Data = new Data(data2) }
                 });
