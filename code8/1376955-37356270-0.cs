    using System;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Web.Services;
    
    namespace Sample
    {
        [WebService(Namespace = "urn:Services")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        public class MyWebService
        {
            [WebMethod]
            public string Request(string request)
            {
                // Step 1: Call the library method to generate data
                var lib = new MyLibrary();
                HostingEnvironment.QueueBackgroundWorkItem((token) =>
                    lib.GenerateDataAsync(() =>
                    {
                        // Step 2: Kick off a process that consumes the data created in Step 1
                    }));
    
                return "some kind of response";
            }
        }
    
        public class MyLibrary
        {
            public async Task GenerateDataAsync(Action onDoneCallback)
            {
                try
                {
                    using (var cmd = new SqlCommand("MyStoredProc", new SqlConnection("my DB connection string")))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Connection.Open();
    
                        // Asynchronously call the stored procedure.
                        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
    
                        // Invoke the callback if it's provided.
                        if (onDoneCallback != null)
                            onDoneCallback();
                    }
                }
                catch (Exception ex)
                {
                    // Handle errors...
                }
            }
        }
    }
