    namespace AndroidParse
    {
        public class DbMonitor
        {
            private readonly string _connectionString = ConfigurationManager.ConnectionStrings["XXXXX"].ConnectionString;
            private SqlDependency _dependency;
            private SqlConnection _conn;
            private SqlCommand _command;
            public void MonitorDatabase()
            {
                SqlDependency.Start(_connectionString);
    
                // Open DB Connection
                using (_conn = new SqlConnection(_connectionString))
                {
                    // Setup SQL Command
                    using (_command = new SqlCommand("SELECT TOP 1 device_id FROM Temp ORDER BY ID_Requests DESC", _conn))
                    {
                        // Create a dependency and associate it with the SqlCommand. *** MAGIC ****
                        _dependency = new SqlDependency(_command);
    
                        // Subscribe to the SqlDependency event.
                        _dependency.OnChange += HandleDatabaseChange;
    
                        // Execute 
                        _command.Connection.Open();
                        _command.ExecuteReader();
                    }
                }
            }
    
            public void Stop()
            {
                SqlDependency.Stop(_connectionString);
            }
    
            private void HandleDatabaseChange(object sender, SqlNotificationEventArgs e)
            {
                if (e.Info == SqlNotificationInfo.Invalid)
                {
                    Console.WriteLine("The above notification query is not valid.");
                }
                else
                {
                    Console.WriteLine("Database Changed based on query");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Event Details:");
                    Console.WriteLine("Notification Info: " + e.Info);
                    Console.WriteLine("Notification source: " + e.Source);
                    Console.WriteLine("Notification type: " + e.Type);
                }
    
                //PushMessage logic here
                bool isPushMessageSend = false;
    
                string postString = "";
                string urlpath = "https://api.parse.com/1/push";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlpath);
    
                // Use Query to get device_id? 
    
                postString = "{\"data\": { \"alert\": \"Finally is working\" },\"where\": { \"device_id\": \"" + "deviceID" + "\" }}";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.ContentLength = postString.Length;
                httpWebRequest.Headers.Add("X-Parse-Application-Id", "XXXX");
                httpWebRequest.Headers.Add("X-Parse-REST-API-KEY", "XXXX");
                httpWebRequest.Method = "POST";
    
                StreamWriter requestWriter = new StreamWriter(httpWebRequest.GetRequestStream());
                requestWriter.Write(postString);
                requestWriter.Close();
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    
    
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    JObject jObjRes = JObject.Parse(responseText);
                    if (Convert.ToString(jObjRes).IndexOf("true") != -1)
                    {
                        isPushMessageSend = true;
                    }
                }
    
                // Resume Monitoring... Requires setting up a new connection, etc.. Reuse existing connection? Tried.
                MonitorDatabase();
            }
        }
    }
    
    class Program
    {
    
        static void Main(string[] args)
        {
            try
            {
                // Start the cheese monitor
                DbMonitor dbMonitor = new DbMonitor();
                dbMonitor.MonitorDatabase();
    
                Console.WriteLine("Monitoring....Press any key to stop.");
                Console.Read();
    
                dbMonitor.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                SqlDependency.Stop(ConfigurationManager.ConnectionStrings["XXXXX"].ConnectionString);
            }
        }
    }
