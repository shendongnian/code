        public ActionResult ExportToExcel()
        {
            string exportName = "FourCourseAudit";
            
            // This allows me to export only the columns I want.
            var exportQuery = query.Select(t => new { t.Campus, t.Student_Name, t.Course_Count });          
                                                
            try
            {                                
                byte[] response;                
                using (var excelFile = new ExcelPackage())
                {   
                    // Use helper functions to fill worksheet and workbook definitions
                    var worksheet = CreateSheet(excelFile,exportName);
                    var workbook = AssignProperties(excelFile,exportName);
                    // Fill worksheet with data to export
                    worksheet
                        .Cells["D1"]
                        .LoadFromCollection(Collection: exportQuery, PrintHeaders: true)                        
                        .Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    
                    worksheet.Cells["A1:F200"].AutoFitColumns();
                    response = excelFile.GetAsByteArray();
                }
                return File(response, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Export.xlsx");
            }
            catch (NullReferenceException) {
                return ViewBag.Errormsg = "There was a null reference exception.";
            }
            catch (ArgumentNullException)
            {
                return ViewBag.Errormsg = "There was an argument null exception.";
            }
        }
