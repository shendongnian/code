    static void Main()
    {
        //context.Dirds
        List<Row> Dirds = new List<Row> { 
                new Row {
                Time = DateTime.Parse("2014-01-01 11:30"),
                ColumnA = 1.1,
                ColumnB = 4.2
            },
    
            new Row {
                Time = DateTime.Parse("2014-01-01 12:00"),
                ColumnA = 2.2,
                ColumnB = 2.0
            },
    
            new Row {
                Time = DateTime.Parse("2014-01-01 09:00"),
                ColumnA = 3.3,
                ColumnB = 1.2
            }
        };
    
        // Build a "getter" for the column that contains the double
        var getter = Getter<Row, double>("ColumnB");
    
		var results = Dirds.Select(r => new GraphPoint {
			DateTimePoint = r.Time,
			ValuePoint = getter(r)
		});
    
        foreach(GraphPoint point in results)
            Console.WriteLine("{0} {1}", point.DateTimePoint, point.ValuePoint);
    
    }
