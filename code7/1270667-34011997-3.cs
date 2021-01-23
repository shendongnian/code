        var allLines = File.ReadAllLines(@"C:\myfile.txt");
        List<Movie> movies =  new List<Movie>();
        movies.AddRange(allLines.Select(m=> new Movie()
        {
            Series = m.Split(new []{':'}).Length > 1? m.Split(new []{':'})[0]: (m.Contains("@")?m.Split(new []{'@'})[0]:m.Split(new []{'='})[0]),
            Name = (m.Split(new[] { ':' }).Length > 1 ? m.Split(new[] { ':' })[1] : m.Split(new[] { ':' })[0]).Split(new[] { '@' })[0].Split(new[] { '=' })[0], 
            Value = (m.Contains("@")?m.Split(new []{'@'})[1]:m.Split(new []{'='})[1]),
        }));
