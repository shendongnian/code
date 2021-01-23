    public List<Movie> GetAvailableDVDs()
    {
        List<Movie> availableFilms = GetAllDVDs() // presuming you have such a method
            .Where(dvd => dvd.STATUS == Availability.Available)
            .Select(dvd => dvd.Film)   
            .ToList();
        return availableFilms;
    }
     
