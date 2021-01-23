    public class PageService
    {
      public IEnumerable<Actualite> GetActualites()
      {
         return db.Actualite.Where(a => a.Afficher)
                                    .OrderByDescending(a => a.Date_publication).ToList();
      }
    }
