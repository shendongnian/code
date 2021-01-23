     var lst = new List<MontlyChartModified>()
            {
                new MontlyChartModified(){StatusID = 1, Count = 0, MonthYear = "Jan 2014"},
                new MontlyChartModified(){StatusID = 2, Count = 1, MonthYear = "Feb 2013"},
                new MontlyChartModified(){StatusID = 1, Count = 2, MonthYear = "Jan 2013"},
                new MontlyChartModified(){StatusID = 3, Count = 1, MonthYear = "Dec 2014"},
                new MontlyChartModified(){StatusID = 2, Count = 0, MonthYear = "Nov 2014"},
                new MontlyChartModified(){StatusID = 5, Count = 6, MonthYear = "Jun 2015"},
            };
    class MontlyChartModified
    {
       public int StatusID { get; set; }
       public int Count { get; set; }
       public string MonthYear { get; set; }
    }
