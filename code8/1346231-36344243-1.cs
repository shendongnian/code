    public bool WriteMovieListToFile()
    {
        try
        {
            using (FileStream fs = new FileStream("MovieList.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter textWriter = new StreamWriter(fs))
            {
                textWriter.WriteLine(movie.Title);
                textWriter.WriteLine(movie.Genre);
                textWriter.WriteLine(movie.Actor);
                textWriter.WriteLine(movie.Year);
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
            return false;
        }
    }        
