    [TestMethod]
    [ExpectedException(typeof(Exception), "Movie Title is mandatory")]
    public void Create()
    {
        var mc = new MoviesController();
        var model = new Movie
        {
            Cast = new[] { "Scott", "Joe", "mark" },
            Classification = "PG",
            Genre = null,
            MovieId = 0,
            Rating = 5,
            ReleaseDate = 2004,
            Title = null
        };
        try
        {
            var rep = mc.Create(model);
            Assert.Fail("This shouldn't be shown, because the above should have thrown an exception ! !");
        }
        catch (Exception e)
        {
            Console.Out.WriteLine("AH ha! caught it ! :) : " + e);
            throw;
        }        
    }
