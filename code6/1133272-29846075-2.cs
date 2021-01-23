    var request = new RootObject
    {
        request = new Request
        {
            passengers = new Passengers
            {
                adultCount = 1
            },
            slice = new List<Slouse>
            {
                new Slouse
                {
                    origin = "LAS",
                    destination = "LAX",
                    date = "2015-04-30"
                }
            },
            solutions = 20,
            refundable = false
        }
    };
