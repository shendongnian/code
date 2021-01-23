    var Date_min = DateTime.Now.AddDays(-4);
            var Date_max = DateTime.Now.AddDays(1);
            var chart = new Chart(width: 600, height: 400, themePath: "XMLFile1.xml")
                       .AddSeries(
                                  chartType: "line",
                                  name: "Temperature",
                                  xValue: new DateTime[] { DateTime.Now.AddDays(-4), DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), DateTime.Now },
                                  yValues: new int[] { 2, 1, 2, 2, 1 })       //0,1 or 2 for green, yellow and red                     
                       .SetXAxis("Date", Date_min.ToOADate(), Date_max.ToOADate())
                       .SetYAxis("Temperature", 0, 3.0)
                       .Save("~/Image/MyChart.png", "png");
     <Series Name="Temperature" BorderWidth="3" >
     </Series>
