    public class QR_DS022Controller : ApiController
    {
       private TestContext db = new TestContext();
    
       [HttpGet]
       [Route("api/qr_ds022/mth_test/{from}/{to}")]
       public IQueryable<getRep_Result> getRepos(DateTime from, DateTime to)
       {
          var results = db.getRep(from, to).AsQueryable();
          return results;
       }
    }
