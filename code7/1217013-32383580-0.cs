    public class CustomPmScheduleGenerator
    {
        public CustomPmScheduleGenerator()
        {
            Pms = new List<stp_GetPmSchedulesGenerator_Result>();
            Repairs = new List<stp_GetRepairSchedulesGenerator_Result>();
        }
        
        public bool Save { get; set; }
        etc..
        public IList<stp_GetPmSchedulesGenerator_Result> Pms { get; set; }
        public IList<stp_GetRepairSchedulesGenerator_Result> Repairs { get; set; } 
    }
