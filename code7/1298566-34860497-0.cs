    var apiKey = System.Configuration.ConfigurationManager.AppSettings["sendgrid_api_key"];
    
    // Create an Web transport for sending email.
    SendGrid.Web transportWeb = new SendGrid.Web(apiKey);
    
    SendGridMessage msg = new SendGridMessage();
    
    msg.Subject = "...";
    msg.AddTo(model.Email);
    msg.Html = body;
    msg.From = new MailAddress("...");
    
    try
    {
      await transportWeb.DeliverAsync(msg);
    }
    catch (Exception e)
    {
      e.ToExceptionless().Submit();
      ViewBag.ErrorMsg = e.Message;
      return View("Error");
    }
