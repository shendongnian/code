    public class SpecialitiesController : ApiController
        {
            private ApplicationDbContext db = new ApplicationDbContext();
    
            public SpecialitiesController()
            {
                db.Configuration.ProxyCreationEnabled = false;
            }
    
            // GET: api/Specialities
            public IQueryable<Speciality> GetSpeciality()
            {
                return db.Speciality;
            }
        }
