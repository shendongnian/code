    [
        HttpPost,
        ValidateAntiForgeryToken
    ]
    public async Task<ActionResult> Index(EmailFormModel model, 
                                          IEnumerable<HttpPostedFileBase> files)   
    {
        try
        {
            if (ModelState.IsValid)
            {
                string EncodedResponse = Request.Form["g-Recaptcha-Response"];
                bool IsCaptchaValid = ReCaptcha.Validate(EncodedResponse) == "True";
                if (IsCaptchaValid)
                {
                    var paths = GetUploadPaths(files);    
                    using (var message = ConstructMailMessage(model))
                    {
                        AppendAttachments(paths, message.Attachments);
                        
                        using (var smtp = new SmtpClient())
                        {
                            var credential = new NetworkCredential
                            {
                                UserName = "...", // replace with valid value
                                Password = "..."  // replace with valid value
                            };
                            smtp.Credentials = credential;
                            smtp.Host = "relay-hosting.secureserver.net";
                            smtp.Port = 25;
                            smtp.Timeout = 1000;
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.UseDefaultCredentials = false;
                            smtp.SendCompleted += (s, e) =>
                            {
                                // Ensure disposed first.
                                foreach (var a in message.Attachments) a.Dispose();
                            
                                foreach (var path in paths) File.Delete(path);
                            };
                            await smtp.SendMailAsync(message);
 
                            ViewBag.Message = "Your message has been sent!";
     
                            ModelState.Clear();
                            return View("Index");
                        }
                    }
                }
                else
                {
                    TempData["recaptcha"] = "Please verify that you are not a robot!";
                }
    
            }
            return View(model);
        }
        catch (Exception ex)
        {
            return View("Error");
        }
    }
