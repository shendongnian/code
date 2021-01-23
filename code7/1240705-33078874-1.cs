    public SelectList GetAsSelectList()
    {
        var enumList = (from Enum e in Enum.GetValues(typeof(FileGenre))
                       select new 
                       {
                           Name = e,
                           Id = Convert.ToInt32(e).ToString()
                       }).ToList();
       return new SelectList((IEnumerable)enumList, "Id", "Name");
    }
