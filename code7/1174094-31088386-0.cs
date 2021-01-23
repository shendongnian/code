    Just in case someone has the same problem:
    
    public ActionResult ExcelExport(string startTimeDD, string startTimeMM, string startTimeYYYY, string endTimeDD, string endTimeMM, string endTimeYYYY)
            {
                DateTime startingTime = new DateTime(Convert.ToInt32(startTimeYYYY), Convert.ToInt32(startTimeMM), Convert.ToInt32(startTimeDD));
                DateTime endingTime = new DateTime(Convert.ToInt32(endTimeYYYY), Convert.ToInt32(endTimeMM), Convert.ToInt32(endTimeDD));
    
                var exportDetails = (from a in db.Rides
                                     join veh in db.Vehicles
                                     on a.VehicleID equals veh.VehicleID
                                     join tou in db.Tours
                                     on a.TourID equals tou.TourID
                                     where a.StartTime > startingTime && a.EndTime < endingTime
                                     join emp in db.Employees
                                     on a.EmployeeID equals emp.EmployeeID
                                     select new { TourID = tou.TourID, VehicleCosts = veh.Cost, EmployeeCosts = emp.Cost }).ToList();
    
                string fileName = String.Format("{0:yyyy-MM-dd}.xlsx", DateTime.Now);
                string path = System.Web.HttpContext.Current.Server.MapPath("/TempFiles/");
    
    
                var fullPath = Path.Combine(path, fileName);
    
    
                using (var sWriter = new StreamWriter(System.IO.File.Create(fullPath)))
                {
                    var csvHelper = new CsvHelper.CsvWriter(sWriter);
                    foreach (var p in exportDetails)
                    {
                        csvHelper.WriteField(p.TourID);
                        csvHelper.WriteField(p.EmployeeCosts);
                        csvHelper.WriteField(p.VehicleCosts);
                        csvHelper.NextRecord();
                    }
    
                    csvHelper.Dispose();
                }
    
                Download(fileName, fullPath);
    
                return Content("n");
            }
            public ActionResult Download(string fileName, string fullPath)
            {
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
                response.ContentType = "text/plain";
                response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ";");
                response.TransmitFile(fullPath);
                response.Flush();
                response.End();
    
                return Content("Generated");
            }
    
    and in the view: 
    
             @using (Html.BeginForm("ExcelExport", "Controlling", new AjaxOptions
                    {
                        HttpMethod = "Post",
                        UpdateTargetId = "Test"
                    }))
