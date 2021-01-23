    public class Job
    {
        private DateTime fromDate;
    
        public Job(DateTime fromDate)
        {             
            Reports = new List<Report>();
            this.fromDate = fromDate;
        }
        ...
        public decimal AverageReportTurnaround
        {
            get
            {
                DateTime reportdate = Reports.Where(x => x.DateCompleted > this.fromDate)
                    .Select(x=> x.DateCompleted).FirstOrDefault();
                return (reportdate - AppointmentDate).Value.Days;
            }
        }
    }
