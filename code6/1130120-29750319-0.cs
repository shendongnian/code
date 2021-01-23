    public class Job
    {
    public Job(DateTime dateFrom)
    {            
        Reports = new List<Report>();
        DateFrom = dateFrom;
    }
    [Key]
    public int JobID { get; set; }
    public ICollection<Report> Reports { get; set; }
    public DateTime AppointmentDate { get; set; }
    public DateTime DateFrom { get; private set; }
    public decimal AverageReportTurnaround
    {
        get
        {
            DateTime reportdate = Reports.Where(x => x.ReportDate > DateFrom).Select(x=>x.DateCompleted).FirstOrDefault();
            return (reportdate - AppointmentDate).Value.Days;
        }
    }
