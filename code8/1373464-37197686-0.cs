    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Index(EmailFormModel model, IEnumerable<HttpPostedFileBase> files) {
        if (ModelState.IsValid) {
            List<string> paths = new List<string>();
            //logic here upload file logic here.
            foreach (var file in files) {
                if (file.ContentLength > 0) {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    file.SaveAs(path);
                    //keep file path for attachments
                    paths.Add(path);
                }
            }
            //Rest of business logic here
            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptcha.Validate(EncodedResponse) == "True" ? true : false);
            if (IsCaptchaValid) {
                var body = "<p>Email From: {0} ({1})</p><p>Subject: {2} </p><p>Message:</p><p>{3}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("***@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("***@ymailcom");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.FromSubject, model.Message);
                message.IsBodyHtml = true;
                //Attach files
                foreach (var path in paths) {
                    //For file information
                    var fileInfo = new FileInfo(path);
                    //stream to store attachment
                    var memoryStream = new MemoryStream();
                    //copy file from disk to memory
                    using (var stream = fileInfo.OpenRead()) {
                        stream.CopyTo(memoryStream);
                    }
                    //reset memory pointer
                    memoryStream.Position = 0;
                    //get file name for attachment based on path
                    string fileName = fileInfo.Name;
                    //add attachment
                    message.Attachments.Add(new Attachment(memoryStream, fileName));
                }
                using (var smtp = new SmtpClient()) {
                    var credential = new NetworkCredential {
                        UserName = "***@gmail.com",  // replace with valid value
                        Password = "***"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    //return RedirectToAction("Sent");
                    ViewBag.Message = "Your message has been sent!";
                    //TempData["message"] = "Message sent";
                    ModelState.Clear();
                    return View("Index");
                }
            } else {
                TempData["recaptcha"] = "Please verify that you are not a robot!";
            }
        }
        return View(model);
    }
