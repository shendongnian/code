      using (ChinookEntities ctx = new ChinookEntities()) {
        List<Func<Album, bool>> predicates = new List<Func<Album, bool>> {
          a => a.Title.Contains("AC"),
        };
        List<Album> albums = ctx.Albums.Where(c => predicates.All(p => p(c))).ToList();
      }
    }
