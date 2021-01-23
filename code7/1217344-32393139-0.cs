    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                CaseModelDatabase caseModelDatabase = new CaseModelDatabase();
                cIssueDetails IssueDetails = new cIssueDetails(); 
                var TicketDetails = (from issuecases in caseModelDatabase.IssueCases
                                     where (DbFunctions.TruncateTime(issuecases.CreatedDate) >= DbFunctions.TruncateTime(IssueDetails.StartDate)
                                     && DbFunctions.TruncateTime(issuecases.CreatedDate) <= DbFunctions.TruncateTime(IssueDetails.ToDate))
                                     where (string.IsNullOrEmpty(IssueDetails.TicketArea) ? true : issuecases.TicketArea == IssueDetails.TicketArea)
                                     where (string.IsNullOrEmpty(IssueDetails.TicketType) ? true : issuecases.TicketType == IssueDetails.TicketType)
                                     where (string.IsNullOrEmpty(IssueDetails.Status) ? true : issuecases.Status == IssueDetails.Status)
                                     select new
                                     {
                                         issuecases.WorkRequestId,
                                         issuecases.Summary,
                                         issuecases.Status,
                                         issuecases.CreatedDate,
                                         issuecases.UpdatedDate
                                     }).ToList();
            }
            public class CaseModelDatabase
            {
                public List<cIssueCases> IssueCases { get; set; }
            }
            public class cIssueCases
            {
                public DateTime CreatedDate { get; set; }
                public string TicketArea { get; set; }
                public string TicketType { get; set; }
                public string Status { get; set; }
                public string Summary { get; set; }
                public int WorkRequestId { get; set; }
                public DateTime UpdatedDate { get; set; }
     
            }
            public class cIssueDetails
            {
                public DateTime StartDate { get; set; }
                public DateTime ToDate { get; set; }
                public string TicketArea { get; set; }
                public string TicketType { get; set; }
                public string Status { get; set; }
                
            }
            public static class DbFunctions
            {
                public static DateTime TruncateTime(DateTime time)
                {
                    return time;
                }
            }
        }
    }
    ​
