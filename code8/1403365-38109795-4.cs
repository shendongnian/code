    public class EmployeeormViewModel
        {
            public string Venue { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }
            public DateTime DateTime
            {
                get
                {
                    return Date.ParseToDateTime(Time);
                }
            }
        }
