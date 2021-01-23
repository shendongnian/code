    using Google.Apis.Auth.OAuth2;
    using System.IO;
    using System.Threading;
    using Google.Apis.Bigquery.v2;
    using Google.Apis.Bigquery.v2.Data;
    using System.Data;
    using Google.Apis.Services;
    using System;
    
    namespace GoogleBigQuery
    {
        public class Class1
        {
            private static void Main()
            {
                UserCredential credential;
                using (var stream = new FileStream("client_secrets.json", FileMode.Open,
                                                FileAccess.Read))
                {
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                       GoogleClientSecrets.Load(stream).Secrets,
                       new[] { BigqueryService.Scope.Bigquery },
                       "user", CancellationToken.None).Result;
                }
    
                //  Create and initialize the Bigquery service. Use the Project Name value
                //  from the New Project window for the ApplicationName variable.
    
                BigqueryService Service = new BigqueryService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "PROJECT NAME"
                });
    
                string query = "YOUR QUERY";
    
                JobsResource j = Service.Jobs;
                QueryRequest qr = new QueryRequest();
                qr.Query = query;
    
                DataTable DT = new DataTable();
                int i = 0;
    
                QueryResponse response = j.Query(qr, "PROJECT ID").Execute();
    
                if (response != null)
                {
                    int colCount = response.Schema.Fields.Count;
    
                    foreach (var Column in response.Schema.Fields)
                    {
                        DT.Columns.Add(Column.Name);
                    }
    
                    foreach (TableRow row in response.Rows)
                    {
                        DataRow dr = DT.NewRow();
    
                        for (i = 0; i < colCount; i++)
                        {
                            dr[i] = row.F[i].V;
                        }
    
                        DT.Rows.Add(dr);
                    }
                }
                else
                {
                    Console.WriteLine("Response is null");
                }
            }
        }
    }
