    public List<Movie> GetAvailableDVDs()
    {
        List<Movie> availableFilms = GetAllDVDs() // presuming you have such a method
            .Where(dvd => dvd.Availability == Availability.Available)
            .Select(dvd => dvd.Film)   
            .ToList();
        return availableFilms;
    }
     
