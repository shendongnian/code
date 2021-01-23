    using (var smtp = new SmtpClient())
    {
           var credential = new NetworkCredential
           {
                  UserName = "***@gmail.com",  
                  Password = "***" 
           };
           smtp.Credentials = credential;
           smtp.Host = "smtp.gmail.com";
           smtp.Port = 587;
           smtp.EnableSsl = true;
           smtp.SendCompleted += (s, e) => {
                                 //delete file
                                 foreach (var path in paths)
                                    System.IO.File.Delete(path);
                             };
           await smtp.SendMailAsync(message);
           ViewBag.Message = "Your message has been sent!";
           ModelState.Clear();
           return View("Index");
    }
