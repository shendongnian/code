     public SelectList GetAsSelectList()
        {
            var genres = (from s in GetAllGenres().OrderBy(x => x.Name)
                            where s.Active
                            select new
                            {
                                s.Id, s.Name
                            }).ToList();
            return new SelectList((IEnumerable)addTypes, "Id", "Name");
        }
