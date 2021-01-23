    public class ReportController : Controller
    {
        CounterContext db = new CounterContext();
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               db.Dispose();
            }
            base.Dispose(disposing);
        }
        public void AddCockpitEnvironmentDetails(IList<Environment> environmentList)
        {
            // You could've gotten it like this instead of passing it in...
            // IEnumerable<Environments> environmentList = db.Environments;
            foreach (Environment entity in environmentList)
            {
                db.Environments.Add(entity);
            }
            db.SaveChanges();
        }
    ....
    }
