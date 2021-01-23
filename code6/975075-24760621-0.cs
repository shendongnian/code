    public class AbstractController<TModelType> : Controller 
        where TModelType : class, IActive
    {
        private readonly DbContext _db;
        public AbstractController()
        {
            _db = new DbContext("connection");
        }
        public ActionResult Toggle(int id)
        {
            TModelType instance = _db.Set<TModelType>().Find(id);
            instance.is_active = instance.is_active == null ? true : !instance.is_active;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
