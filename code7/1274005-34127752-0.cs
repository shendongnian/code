     public ActionResult Index(DateTime? dteStartDate, DateTime? dteEndDate)
        {
           
            if (dteStartDate != null && dteEndDate != null)
               {
           
                    //var @StartDate = new SqlParameter("@StartDate", dteEndDate);
                   // var @EndDate = new SqlParameter("@EndDate", dteEndDate);
                string query = "SELECT E.EMPLID, E.FIRSTNAME, E.LASTNAME, E.WAGE, H.CLOCKINTIME, H.CLOCKOUTTIME, DATEDIFF(HOUR, H.CLOCKINTIME, H.CLOCKOUTTIME) AS HOURS_WORKED, E.WAGE * DATEDIFF(HOUR, H.CLOCKINTIME, H.CLOCKOUTTIME) AS DAILY_EARNINGS "
                    + "FROM EMPLOYEE E "
                    + "JOIN HOURLYWAGEMGMT H "
                    + "ON H.EMPLID = E.EMPLID "
                    + "WHERE E.POSITION = 'Driver' "
                    + "AND H.CLOCKINDATE BETWEEN '" + dteStartDate + "' AND '" + dteEndDate + "' "
                    + "AND H.CLOCKOUTDATE BETWEEN '" + dteStartDate + "' AND '" + dteEndDate + "' ";
               
                var data = db.Database.SqlQuery<Payroll>(query);
                var pck = new OfficeOpenXml.ExcelPackage();
                var ws = pck.Workbook.Worksheets.Add("Payroll");
                ws.Cells["A2"].LoadFromCollection(data, false);
                ws.Cells["A1"].Value = "EmployeeID";
                ws.Cells["B1"].Value = "FirstName";
                ws.Cells["C1"].Value = "LastName";
                ws.Cells["D1"].Value = "Wage";
                ws.Cells["E1"].Value = "ClockInTime";
                ws.Cells["F1"].Value = "ClockOutTime";
                ws.Cells["G1"].Value = "HoursWorked";
                ws.Cells["H1"].Value = "DailyEarnings";
                using (ExcelRange rng = ws.Cells["A1:H1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                    rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                }
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=Payroll.xlsx");
                Response.BinaryWrite(pck.GetAsByteArray());
            
           
            Response.End();
            return View();
             }
            else
            {
              return View();
             }
        }
    }
}
