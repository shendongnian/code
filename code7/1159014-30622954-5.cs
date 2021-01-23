        public class Rootobject
        {
            public Result[] Results { get; set; }
        }
        public class Result
        {
            public string MlsCode { get; set; }
            public string MlsAgentId { get; set; }
            public object UserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string OfficeName { get; set; }
            public string MlsOfficeId { get; set; }
            public string[] Phones { get; set; }
        }
