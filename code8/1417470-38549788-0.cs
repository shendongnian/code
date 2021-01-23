        class Flight
        {
            public bool IsDeparture;
            public string OnlyTour;
            public string OnlyPhone;
            public DateTime FlightDateFull;
            public decimal PriceView;
        }
        [TestMethod]
        public void FlightTest()
        {
            // Arrange
            var flightList = new List<Flight> {
                new  Flight { IsDeparture = true, OnlyPhone = "0", OnlyTour = "0", FlightDateFull = new DateTime(2016,8,7), PriceView = 1 },
                new  Flight { IsDeparture = true, OnlyPhone = "0", OnlyTour = "0", FlightDateFull = new DateTime(2016,8,7), PriceView = 2 },
                new  Flight { IsDeparture = true, OnlyPhone = "0", OnlyTour = "0", FlightDateFull = new DateTime(2016,8,8), PriceView = 2 },
                new  Flight { IsDeparture = true, OnlyPhone = "0", OnlyTour = "0", FlightDateFull = new DateTime(2016,8,8), PriceView = 3 }
            };
            // Act
            var result = (from flights in flightList
                          where flights.IsDeparture && flights.OnlyTour == "0" && flights.OnlyPhone == "0"
                          group flights by flights.FlightDateFull into grouping
                          select new { Date = grouping.Key, MinPrice = grouping.Min(a => a.PriceView) }).OrderBy(a => a.Date).ToList();
            // Assert
            Assert.AreEqual(new DateTime(2016, 8, 7), result[0].Date);
            Assert.AreEqual(1, result[0].MinPrice);
            Assert.AreEqual(new DateTime(2016, 8, 8), result[1].Date);
            Assert.AreEqual(2, result[1].MinPrice);
        }
