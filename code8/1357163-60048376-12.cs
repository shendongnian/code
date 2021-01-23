    namespace WeeklyReport.Repository
    {
        public interface IDataRepository
        {
            void SaveChanges();
            IEnumerable<ReportViewModel> GetAllMetrics();
        }
    }
