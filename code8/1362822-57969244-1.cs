using Google.Apis.AnalyticsReporting.v4.Data;
using System;
namespace ConsoleApplication {
    class Program {
        static void Main(string[] args) {
            var credential = Google.Apis.Auth.OAuth2.GoogleCredential.FromFile("serviceAccount.json")
                .CreateScoped(new[] { Google.Apis.AnalyticsReporting.v4.AnalyticsReportingService.Scope.AnalyticsReadonly });
            using (var analytics = new Google.Apis.AnalyticsReporting.v4.AnalyticsReportingService(new Google.Apis.Services.BaseClientService.Initializer {
                HttpClientInitializer = credential
            })) {
                var request = analytics.Reports.BatchGet(new GetReportsRequest {
                    ReportRequests = new[] {
                        new ReportRequest{
                            DateRanges = new[] { new DateRange{ StartDate = "2019-01-01", EndDate = "2019-01-31" }},
                            Dimensions = new[] { new Dimension{ Name = "ga:date" }},
                            Metrics = new[] { new Metric{ Expression = "ga:sessions", Alias = "Sessions"}},
                            ViewId = "99999999"
                        }
                    }
                });
                var response = request.Execute();
                foreach (var row in response.Reports[0].Data.Rows) {
                    Console.Write(string.Join(",", row.Dimensions) + ": ");
                    foreach (var metric in row.Metrics) Console.WriteLine(string.Join(",", metric.Values));
                }
            }
            Console.WriteLine("Done");
            Console.ReadKey(true);
        }
    }
}
  [1]: https://console.cloud.google.com/apis
  [2]: https://console.developers.google.com/iam-admin/serviceaccounts
