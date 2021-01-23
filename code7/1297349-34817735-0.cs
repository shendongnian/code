    public ActionResult Index(FormCollection formCollection)
    {
        // your previous code
        try
        {
            using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
            {
                smtp.Credentials = new NetworkCredential(emailFrom, password);
                smtp.EnableSsl = enableSSL;
                smtp.Send(mail);
            }
        }
        catch (Exception e)
        {
             ViewBag.HasError = true;
             ViewBag.ErrorMessage = e.Message;
        }
        return View(/*whatever extra info you like*/);
    }
