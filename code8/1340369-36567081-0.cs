    string GetSerials = "SELECT SerialNumber from Warranty";
                    string TestUpdateDates = "UPDATE Warranty SET StartDate = '@StartDate', EndDate = @EndDate WHERE SerialNumber = @result";
                    //string TestUpdateDates2 = "UPDATE Warranty SET StartDate = cDate(Format(@StartDate, 'MM/dd/yyyy')), EndDate = cDate(Format(@EndDate, 'MM/dd/yyyy')) WHERE(SerialNumber = @result)";
        
        DataTable dataTable = new DataTable();
          using (var conn1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Blah\Blah\Blah\Warranty.accdb"))
          using (OleDbCommand serialCommand = new OleDbCommand(GetSerials, conn1))
          {
            conn1.Open();
            dataTable.Load(serialCommand.ExecuteReader());
        
            foreach (DataRow row in dataTable.Rows)
            {
              var result = row["SerialNumber"].ToString();
              WebRequest request = WebRequest.Create("urlpart1" + result + "urlpart2");
              string json;
              var response = request.GetResponse();
              request.ContentType = "application/json; charset=utf-8";
        
              using (var streamr = new StreamReader(response.GetResponseStream()))
              using (OleDbCommand testupdateCommand = new OleDbCommand(TestUpdateDates, conn1))
              using (OleDbCommand updateCommand = new OleDbCommand(UpdateDates, conn1))
              using (OleDbCommand deleteCommand = new OleDbCommand(DeleteIncomplete, conn1))
              {
                json = streamr.ReadToEnd();
                List<MyObject> list = JsonConvert.DeserializeObject<List<MyObject>>(json);
                MyObject obj = list[0]; //Base Warranty
        
                // obj -- Base Warranty
                var StartDate = obj.Start;
                var EndDate = obj.End;
        
                //testupdateCommand.Parameters.Add("@StartDate", OleDbType.Date).Value = StartDate;
                //testupdateCommand.Parameters.Add("@EndDate", OleDbType.Date).Value = EndDate;
                testupdateCommand.Parameters.AddWithValue("@StartDate", StartDate);
                testupdateCommand.Parameters.AddWithValue("@EndDate", EndDate);
                testupdateCommand.Parameters.AddWithValue("@result", result);
