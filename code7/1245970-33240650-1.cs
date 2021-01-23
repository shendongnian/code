    [TestMethod]
    public void TestingWeatherStationsRequiredLinq()
    {
        List<Reading> readings = new List<Reading>
            {
            new Reading { WeatherStationID = "1", ReadingID = 1, Reading_Date = new DateTime(01/01/2014), Date_Taken = new DateTime(01/01/2014), Avg_Temperature = 6, Max_Temperature = 8, Min_Temperature = 2},
            new Reading { WeatherStationID = "1", ReadingID = 2, Reading_Date = new DateTime(02/01/2014), Date_Taken = new DateTime(02/01/2014), Avg_Temperature = 1, Max_Temperature = 1, Min_Temperature = 1},
            new Reading { WeatherStationID = "1", ReadingID = 3, Reading_Date = new DateTime(03/01/2014), Date_Taken = new DateTime(03/01/2014), Avg_Temperature = 3, Max_Temperature = 3, Min_Temperature = 3},
            new Reading { WeatherStationID = "2", ReadingID = 4, Reading_Date = new DateTime(01/02/2014), Date_Taken = new DateTime(01/02/2014), Avg_Temperature = 8, Max_Temperature = 8, Min_Temperature = 8},
            new Reading { WeatherStationID = "2", ReadingID = 5, Reading_Date = new DateTime(01/03/2014), Date_Taken = new DateTime(01/03/2014), Avg_Temperature = 9, Max_Temperature = 9, Min_Temperature = 9},
            new Reading { WeatherStationID = "2", ReadingID = 6, Reading_Date = new DateTime(01/04/2014), Date_Taken = new DateTime(01/04/2014), Avg_Temperature = 11, Max_Temperature = 11, Min_Temperature = 11}
        };
        RequiredStations requiredStations = new RequiredStations();
        var result = requiredStations.Stations(readings.AsQueryable());
        //assert things about result here
    }
