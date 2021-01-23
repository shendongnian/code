    namespace WeeklyReport.Repository
    {
        public class DataRepository : IDataRepository
        {
            private bool disposing;
            private readonly Model1 context;
            public virtual void Dispose()
            {
                if (disposing)
                {
                    return;
                }
                disposing = true;
                if (context != null)
                {
                    context.Dispose();
                }
            }
            public void SaveChanges()
            {
                context.SaveChanges();
            }
            public DataRepository()
            {
                context = new Model1();
                context.Configuration.ProxyCreationEnabled = false;
            }
            public IEnumerable<ReportViewModel> GetAllMetrics()
            {
                var myMetrics = context.MetricsTable; // put into ReportVM and return, etc.
            }
            // etc., etc.
        }
    }
        
