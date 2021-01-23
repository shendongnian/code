    Controller
    
    [HttpPost]
            public ActionResult Save(List<HttpPostedFileBase> fileUpload, TicketSystemAPI.Models.Tickets.Ticketss ticket)
            {
    
                if (!Helper.Common.LogedInUser())
                    return RedirectToAction("Login", "Logins");
    
                List<string> myTempPaths = new List<string>();
    
                if (fileUpload.Count > 1)
                {
    
    
                    foreach (var file in fileUpload)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
    
                            int MaxContentLength = 1024 * 1024 * 3; //3 MB
                            string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png" };
                            if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                            {
                                ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                                TempData["error"] = ("Please file of type: " + string.Join(", ", AllowedFileExtensions));
    
                                // return ("TicketsEdit",TempData["error"].ToString());
                            }
                            else if (file.ContentLength > MaxContentLength)
                            {
                                ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                            }
                            else
                            {
                                string extension = Path.GetExtension(file.FileName);
                                string fileName = DateTime.Now.ToString("ddMMyyHHmmss").ToString() + extension;
                                //         TempData["FileName"] = fileName;
    
    
                                //var filename = Guid.NewGuid() + Path.GetFileName(file.FileName);
                                //file.SaveAs(Path.Combine(Server.MapPath("~/Attach/Document"), Guid.NewGuid() + Path.GetExtension(file.FileName)));
                                file.SaveAs(Path.Combine(Server.MapPath("~/Attach/Document"), fileName + Path.GetExtension(file.FileName)));
                                ModelState.Clear();
                                //       ViewBag.Message = "File uploaded successfully";
                                myTempPaths.Add(fileName);
                            }
                        }
                    }
                }
    
    
    
    View 
    
    
    @using (Html.BeginForm("Save", "Tickets",
    FormMethod.Post, new { enctype = "multipart/form-data", id = "frmID" }))
    {
        @Html.HiddenFor(i => i.FileName)
    
        <div class="labelstyle">
            <label>Files</label>
        </div>
    
        <div id="uploaders">
            <input type="file" id="fileToUpload"
                   name="fileUpload" multiple="multiple" style="float: left;" />
            <br />
            <span id="spnFile" style="float: left; color: #FF0000"></span>
            @Html.ValidationMessage("File")
            @Html.Hidden("hdnFileUpload")
        </div>
        <br />
        <div class="col-lg-6">
            <button class="btn btn-primary" id="btnAddIssue" type="submit">Submit</button>
        </div>
        <br />
        <div class="control-section" style="padding: 0px;">
            <div id="selectedFiles"></div>
        </div>
    }
