public static List<Movie> movies;
public static Movie getMovieByName(string name)
{
    foreach(Movie m in movies)
    {
        if(m.name == name)
            return m;
    }
    throw new InvalidMovieException(name);
}
