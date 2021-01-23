    [HttpPost]
    public async Task<ActionResult> Contact(FormCollection C)
    {
          string Name = C["name"];
          string Email = C["email"];
          string Message = C["message"];
          if (ModelState.IsValid)
          {
              var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
              var message = new MailMessage();
              message.To.Add(new MailAddress("yourmail@yahoo.com"));  // replace with valid value 
              message.From = new MailAddress("yourmail@Domain.com");  // replace with valid value
              message.Subject = "Your email subject";
              message.Body = string.Format(body, Name, Email, Message);
              message.IsBodyHtml = true;
              using (var smtp = new SmtpClient())
              {
                  var credential = new NetworkCredential
                      {
                            UserName = "yourmail@Domain.com",  // replace with valid value
                            Password = "********"  // replace with valid value
                      };
                      smtp.Credentials = credential;
                      smtp.Host = "webmail.Domain.com";//address webmail
                      smtp.Port = 587;
                      smtp.EnableSsl = false;
                      await smtp.SendMailAsync(message);
                      return RedirectToAction("Index");
                  }
            }
                  return View();
    }
