        public class ActivitiesReportViewModel
    {
    
        public ActivitiesReportViewModel()
        {
            ActivityTypeList = new List<ActivityType>();
            ActivityList = new List<Activity>();
            ClientList = new List<Client>();
            ActivityCounterList = new List<List<ActivityCounter>>();
        }
    
        [DisplayName("Responsável")]
        public string UserName { get; set; }
    
        [DisplayName("Data Inicial")]
        [Required]
        public DateTime DateFrom { get; set; }
    
        [DisplayName("Data Final")]
        [Required]
        public DateTime DateTo { get; set; }
    
        [DisplayName("Tipos de Atividade")]
        public virtual List<ActivityType> ActivityTypeList { get; set; }
    
        [DisplayName("Atividades")]
        public virtual List<Activity> ActivityList { get; set; }
    
        [DisplayName("Clientes")]
        public virtual List<Client> ClientList { get; set; }
    
        public List<List<ActivityCounter>> ActivityCounterList { get; set; }
    
    }
