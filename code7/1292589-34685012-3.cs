    private static void AddShows(NettlesContext db)
    {
        var fulton = new Venue()
                {
                    Name = "Fulton Community Center",
                };
        var club = new Venue()
                {
                    Name = "Milwaukie Community Club",
                };
        db.Venues.Add(fulton);
        db.Venues.Add(club);
        var shows = new List<Show>()
        {
            new Show()
            {
                Title = "Portland Country Dance Community Contra Dance",
                Venue = fulton,
            },
            new Show()
            {
                Title = "Portland Roadhouse Contra Dance",
                Venue = club
            },
        };
        context.Shows.AddRange(shows);
    }
