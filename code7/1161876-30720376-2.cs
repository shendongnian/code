    public class TaskController : Controller
    {
        [HttpPost]
        public ActionResult ParseToExcel(HttpPostedFileBase[] filesUpload)
        {
            decimal currentFile = 1.0M;
            int fileProgress = 0;
            int maxCount = filesUpload.Count();
            // Initialize Hub context
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();
            hubContext.Clients.All.sendMessage("Initalizing...", fileProgress);            
            try
            {
                // Map server path for temporary file placement (Generate new serialized path for each instance)
                var tempGenFolderName = DateTime.Now.ToString("yyyyMMdd_HHmmss"); //SubstringExtensions.GenerateRandomString(10, false);
                var tempPath = Server.MapPath("~/" + tempGenFolderName + "/");
                // Create Temporary Serialized Sub-Directory
                FileInfo thisFilePath = new FileInfo(tempPath);
                thisFilePath.Directory.Create();
                // Iterate through PostedFileBase collection
                foreach (HttpPostedFileBase file in filesUpload)
                {
                    // Does this iteration of file have content?
                    if (file.ContentLength > 0)
                    {
                        fileProgress = Convert.ToInt32(Math.Round(currentFile / maxCount * 100, 0));
                        // Indicate file is being uploaded
                        hubContext.Clients.All.sendMessage("Uploading " + Path.GetFileName(file.FileName), fileProgress);
                        file.SaveAs(Path.Combine(thisFilePath.FullName, file.FileName));
                        currentFile++;
                    }
                }
                // Initialize new ClosedXML/Excel workbook
                //var hl7Workbook = new XLWorkbook();
                // Restart progress
                currentFile = 1.0M;
                maxCount = Directory.GetFiles(tempPath).Count();
                // Iterate through the files saved in the Temporary File Path
                foreach (var file in Directory.EnumerateFiles(tempPath))
                {
                    var fileNameTmp = Path.GetFileName(file);
                    fileProgress = Convert.ToInt32(Math.Round(currentFile / maxCount * 100, 0));
                    // Update status
                    hubContext.Clients.All.sendMessage("Parsing " + Path.GetFileName(file), fileProgress);
                    // Initialize string to capture text from file
                    string fileDataString = string.Empty;
                    // Use new Streamreader instance to read text
                    using (StreamReader sr = new StreamReader(file))
                    {
                        fileDataString = sr.ReadToEnd();
                    }
                    // Do more work with the file, adding file contents to a spreadsheet...
                    currentFile++;
                }
                // Delete temporary file 
                thisFilePath.Directory.Delete();
                // Prepare Http response for downloading the Excel workbook
                //Response.Clear();
                //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //Response.AddHeader("content-disposition", "attachment;filename=\"hl7Parse_" + DateTime.Now.ToString("MM-dd-yyyy") + ".xlsx\"");
                // Flush the workbook to the Response.OutputStream
                //using (MemoryStream memoryStream = new MemoryStream())
                //{
                //    hl7Workbook.SaveAs(memoryStream);
                //    memoryStream.WriteTo(Response.OutputStream);
                //    memoryStream.Close();
                //}
                //Response.End();
            }
            catch (Exception ex)
            {
                ViewBag.TaskMessage =
                    "<div style=\"margin-left:15px;margin-right:15px\" class=\"alert alert-danger\">"
                    + "<i class=\"fa fa-exclamation-circle\"></i> "
                    + "An error occurred during the process...<br />"
                    + "-" + ex.Message.ToString()
                    + "</div>"
                    ;
            }
            return View();
        }
    }
