            QPXExpressService service = new QPXExpressService(new BaseClientService.Initializer()
            {
                ApiKey = "xxxx",
                ApplicationName = "Daimto URL shortener Sample",
            });
            TripsSearchRequest x = new TripsSearchRequest();
            x.Request = new TripOptionsRequest();
            x.Request.Passengers = new PassengerCounts { AdultCount = 2 };
            x.Request.Slice = new List<SliceInput>();
            x.Request.Slice.Add(new SliceInput() { Origin = "ADD", Destination = "NBO", Date = "2015-10-29" });
            x.Request.Solutions = 10;
            var result = service.Trips.Search(x).Execute();
