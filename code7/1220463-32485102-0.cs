    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                IEnumerable<RecordToSend> recordsToSend = new List<RecordToSend>() {
                    new RecordToSend() { ApplicationId = System.Guid.Parse("00000001-0001-0001-0001-000000000123"), Schedule = ScheduleTypes.Daily},
                    new RecordToSend() { ApplicationId = System.Guid.Parse("00000001-0001-0001-0001-000000000123"), Schedule = ScheduleTypes.Weekly},
                    new RecordToSend() { ApplicationId = System.Guid.Parse("00000001-0001-0001-0001-000000000123"), Schedule = ScheduleTypes.Monthly},
                    new RecordToSend() { ApplicationId = System.Guid.Parse("00000001-0001-0001-0001-000000000456"), Schedule = ScheduleTypes.Daily},
                    new RecordToSend() { ApplicationId = System.Guid.Parse("00000001-0001-0001-0001-000000000456"), Schedule = ScheduleTypes.Weekly}
                };
                var results = recordsToSend.AsEnumerable()
                    .GroupBy(x => x.ApplicationId)
                    .Select(x => new {
                        ApplicationID = x.Key, 
                        Schedule = x.Select(y => (int)y.Schedule).Sum()
                     }).ToList();
            
            }
        }
        [Flags]
        public enum ScheduleTypes
        {
            None = 0,
            Daily = 1,
            Weekly = 2,
            Monthly = 4
        }
        public class RecordToSend
        {
            public Guid ApplicationId { get; set; }
            public ScheduleTypes Schedule { get; set; }
        }
    }
    ​
