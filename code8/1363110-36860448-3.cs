    private List<Flight> GetRoute(string from, string to, IEnumerable<Flight> allFlights)
    {
        // Check if the route already exists! 
        var desiredRoute = allFlights.FirstOrDefault(r => r.From == from && r.To == to);
        if (desiredRoute != null)
        {
            return desiredRoute.Flights ?? new List<Flight> { desiredRoute };
        }
        // use inner join to find possible matches with the from and to with the currently available flights/routes
        var routes = allFlights.Join(allFlights, f1 => f1.To, f2 => f2.From, (f1, f2) =>
                                new Flight
                                {
                                    // New route found
                                    From = f1.From,
                                    To = f2.To,
    
                                    // sub Flights for the new route
                                    Flights = new List<Flight> { f1, f2 }
                                }).ToList();
    
        // start a new search with the newly found routes
        return GetRoute(from, to, allFlights.Concat(routes));
    }
