    public async Task<ActionResult> Register(RegisterViewModel model)
    {
       ...
       await Utility.MailUtility.SendEmailAsync(user.Email, user.To, msg, subj));
       return RedirectToAction("Index", "Home");
    }
    // No need to add `async` here as there is no `await` inside,
    // possibly can be removed altogether.
    public static Task SendEmailAsync(params etc...) 
    {
        return SendMailForTemplateID(params etc...);
    }
    private async static Task SendMailForTemplateID(params etc...)
    {
         // not Task.Run / Task.Factory.StartNew
         using (MailMessage message = ... )
         using (SmtpClient smtp = ....)
         {
                .... // setup message/smtp
                await smtp.SendMailAsync(mail); // Task-based Send
         }
         // no need to return anything for `Task` (essentially `void`) method 
       } 
