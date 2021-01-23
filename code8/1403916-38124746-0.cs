    public class CRUD
    {
        Repository repository = new Repository(); 
        List<string> activeTech;
        public CRUD()
        {
           activeTech = repository.getAll().ToList();
        }
    }
