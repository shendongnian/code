    if (ModelState.IsValid)
            {
                    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                    var message = new MailMessage();
                    message.To.Add(new MailAddress("nengelen@online.nl")); //replace with valid value
                    message.Subject = model.subject;
                    message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                    message.IsBodyHtml = true;
                    using (var smtp = new SmtpClient())
                    {
                        await smtp.SendMailAsync(message);
                    }
                    message2 = "Thanks! We'll get back to you soon.";
                    //Response.Write("Error sending email: " + error.Message + "<br /> StackTrace: " + error.StackTrace);
                //ViewBag.Message = "Thank you for contact us";
                //return new RedirectToActionAnchor("Contact", "", "#contact");
                TempData["Message"] = message2;
            if (Request.IsAjaxRequest())
            {
                return new JsonResult { Data = new { success = true, message = message2 } };
            }
                return new RedirectResult(Url.Action("") + "#contact");
            }
            else
            {
                return View();
            }
            
  
