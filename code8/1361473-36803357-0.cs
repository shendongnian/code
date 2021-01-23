    public interface IReportGenerator
    {
        string Build(ReportSetting setting);
    }
    
    public class ReportSetting
    {
        public int PersonId { get; set; }
        public Guid CarMake { get; set; }
        public Guid CarModel { get; set; }
    }
    
    public class PersonReportGenerator : IReportGenerator
    {
        private readonly IPersonDb _personDb;
    
        public PersonReportGenerator(IPersonDb personDb)
        {
            _personDb = personDb;
        }
    
        public string Build(ReportSetting setting)
        {
            // you can use setting.PersonId
        }
    }
    
    public class CarReportGenerator : IReportGenerator
    {
        private readonly ICarDb _cardDb;
        public CarReportGenerator(ICarDb cardDb)
        {
            _cardDb = cardDb; 
        }
    
        public string Build(ReportSetting setting)
        {
            // you can use setting.CarMake and setting.CarModel
        }
    }
