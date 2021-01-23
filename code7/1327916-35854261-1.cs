            DateTime dt = new DateTime(2016, 2, 27);
            Highcharts chart = new Highcharts("graph")
               .SetTitle(new Title { Text = "Incoming Stats" })
               .SetXAxis(new XAxis { Type = AxisTypes.Datetime })
               .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Amount Incoming" } })
               .SetSeries(new[]
                 {
                  new Series { Name = "inc", Data = new Data(new object[,] { 
                      {dt , 23 }, 
                      {dt.AddDays(1) , 223 }, 
                      {dt.AddDays(2) , 51 }, 
                      {dt.AddDays(11) , 200 }, }) },
                  new Series { Name = "exp", Data = new Data(new object[,] { 
                      {dt.AddDays(5) , 100 }, 
                      {dt.AddDays(6) , 23 }, 
                      {dt.AddDays(11) , 23 }, 
                      {dt.AddDays(19) , 35 }, 
                      {dt.AddDays(35) , 288 }, }) }
                 });
