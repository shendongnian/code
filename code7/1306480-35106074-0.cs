    [HttpPost]
    public IActionResult SendEmail(Forms NewContact)
    {
        if (ModelState.IsValid)
        {
            // model is valid, you can send email now
            string body = "First Name: " + NewContact.FirstName + "\n"
                                + "Last Name:" + NewContact.LastName + "\n"
                                + "Company:" + NewContact.Company + "\n\n"
                                + "Comments:" + NewContact.Comments;
            MailMessage mailBody = new MailMessage("Something@example.com", "Somethingelse@example.com");
            mailBody.Subject = "Contact Form";
            mailBody.Body = body;
            SmtpClient smtpClient = new SmtpClient("smtp.aol.com", 587);
            smtpClient.Credentials = new NetworkCredential()
            {
                UserName = UserNameHidden,
                Password = PasswordHidden
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailBody);
        
            return Redirect("Contact");
        }
        else
        {
            // model contains validation errors
            // return the same view so form is populated with existing values, 
            // and validation errors are shown
            //
            // You are responsible for populating model values in view page
            // it will be done automatically if you're using tag helpers like @Html.EditorFor()
            return View("Contact", model);
        }
    }
