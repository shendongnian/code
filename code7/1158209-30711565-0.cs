    public class AirlinesController : ODataController<Airline>
       {
            [EnableQuery]
            public IQueryable<Airline> Get()
            {
                DB db = Request.GetContext();
                return db.Airlines();
            }
       }
