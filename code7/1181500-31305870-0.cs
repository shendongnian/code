    public List<Entity> GetAll(List<string> includes>)
    {
         DbQuery<Entity> entites = context.Entites;
         foreach(string s in includes)
         {
              entities = entites.Include(s);
         }
         return entites.ToList();
    }
