     public SelectList GetAsSelectList()
        {
            var genres = (from s in GetAllGenres()
                            select new
                            {
                                s.Id, s.Name
                            }).ToList();
            return new SelectList((IEnumerable)genres, "Id", "Name");
        }
