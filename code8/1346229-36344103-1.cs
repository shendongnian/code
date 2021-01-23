    public bool WriteMovieListToFile()
    {
        try
        {
            FileStream fs = new FileStream("MovieList.txt", FileMode.Append, FileAccess.Write);
            StreamWriter textWriter = new StreamWriter(fs);
            textWriter.WriteLine(movie.Title);
            textWriter.WriteLine(movie.Genre);
            textWriter.WriteLine(movie.Actor);
            textWriter.WriteLine(movie.Year);
            textWriter.Close();
            fs.Dispose();
            fs.Flush();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
            return false;
        }
    }
