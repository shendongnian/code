    public IEnumerable<SelectListItem> GetGenres() 
    {
         foreach (var genre in dbContext.Genres)
         {
              yield return new SelectListItem 
                  {
                      Value = genre.Id.ToString(),
                      Text = genre.Name
                  };
         }
    }
