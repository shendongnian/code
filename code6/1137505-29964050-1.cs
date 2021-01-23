    public ActionResult Report()
    {
         string sql = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "../00002165_Report.sql");
         List<ReportDataModel> model=new List<ReportDataModel>();
         using (NpgsqlConnection con = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=6060;Database=hotelreal;"))
         {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                con.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        model.Add(
                           new ReportDataModel() {
                               fName = reader["fName"], 
                               lName = reader["lName"],
                               preferences= reader["preference"]
                           });
                    }
                }
                catch (Exception e)
                { 
    
                }
         }
    
         return View(model);
    }
