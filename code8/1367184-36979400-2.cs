    public List<Movie> GetAvailableDVDs()
    {
        List<Movie> availableFilms = new List<Movie>();
        foreach(DVD dvd in GetAllDVDs())
        {
            if(dvd.Availability == Availability.Available)
            {
                availableFilms.Add(dvd.Film);
            }
        }
        return availableFilms;
    }
