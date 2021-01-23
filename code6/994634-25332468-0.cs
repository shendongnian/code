    namespace EnumMemberTest.Controllers
    {
        [DataContract(Namespace = "")]
        public enum ScheduleDatePeriod
        {
            [EnumMember(Value = "0"), Display(Name = "None")]
            None = 0,
            [EnumMember(Value = "1"), Display(Name = "Day")]
            Day = 1,
            [EnumMember(Value = "2"), Display(Name = "Week")]
            Week = 2
        }
    
        public class EditEventScheduleSettingsModel
        {
            public ScheduleDatePeriod? Period { get; set; }
        }
    
        //Posting this
        // {
        //   Period: 1
        // }
        public class ValuesController : ApiController
        {
            public void Post(EditEventScheduleSettingsModel settings)
            {
                // settings.Period == Day
            }
        }
    }
