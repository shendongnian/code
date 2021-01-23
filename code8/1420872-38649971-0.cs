         string connectionString = ConfigurationManager.ConnectionStrings["ProConnection"].ConnectionString;
            using (OracleConnection dbConn = new OracleConnection(connectionString))
            {
                var inconditions = id.Distinct().ToArray();
                var srtcon = string.Join(",", inconditions);
                DataSet userDataset = new DataSet();
                var strQuery = @"SELECT * from STCD_PRIO_CATEGORY_DESCR where STCD_PRIO_CATEGORY_DESCR.STD_REF IN (" + srtcon + ")";
                using (OracleCommand selectCommand = new OracleCommand(strQuery, dbConn))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(selectCommand))
                    {
                        DataTable selectResults = new DataTable();
                        adapter.Fill(selectResults);
                        string result = JsonConvert.SerializeObject(selectResults);
                        string contentDisposition = "inline; filename=abc.json";
                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result,         MediaTypeHeaderValue.Parse("application/json"));
                       response.Content.Headers.ContentDisposition =  ContentDispositionHeaderValue.Parse(contentDisposition); 
                return response;
           }
       }
