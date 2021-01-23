    public ActionResult GetTemp(int quantity)
        {
            decimal TemperatureCelcius;
            DateTime TimeOfReading;
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["rpiDB"].ConnectionString.ToString();
            List<Reading> TempTemperatureList = new List<Reading> { };
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand GetTemperature = new SqlCommand("SELECT TOP " + quantity + " * FROM tbl_temp ORDER BY time DESC;", Connection);
            Connection.Open();
            SqlDataAdapter TempAdapter = new SqlDataAdapter(GetTemperature);
            DataTable TempereatureSensorDataTable = new DataTable();
            TempAdapter.Fill(TempereatureSensorDataTable);
            for (int i = 0; i < quantity; i++)
            {
                TemperatureCelcius = (decimal)TempereatureSensorDataTable.Rows[i][0];            
                TimeOfReading = (DateTime)TempereatureSensorDataTable.Rows[i][1];
                TempTemperatureList.Add(new Reading(TemperatureCelcius, TimeOfReading.ToString("HH:mm")));
            }
            Connection.Close();
          
            return Json(TempTemperatureList, JsonRequestBehavior.AllowGet);
        }
