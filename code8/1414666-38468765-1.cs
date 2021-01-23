    using Oracle.ManagedDataAccess.Client;
    using System.Data;
    using Newtonsoft.Json;
        public string Get()
        {
            var strQuery = @"The above query";
            OracleConnection dbConn = new OracleConnection("DATA SOURCE=ABC;PASSWORD=ABCD;PERSIST SECURITY INFO=True;USER ID=ABCDE");
            dbConn.Open();
            OracleCommand selectCommand = new OracleCommand(strQuery, dbConn);
            OracleDataAdapter adapter = new OracleDataAdapter(selectCommand);
            DataTable selectResults = new DataTable();
            adapter.Fill(selectResults);
            dbConn.Close();
            return JsonConvert.SerializeObject(selectResults);  
        }
