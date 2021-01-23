    // use it directly
                    var emailService = new EmailService();
                    IdentityMessage msg = new IdentityMessage()
                    {
                        Destination = "test <test@domain.com>",
                        Subject = "Subject",
                        Body = "Body"
                    };
    
                    emailService.AddTo("Name1", "mail1@domain.com");
                    emailService.AddTo("Name2", "mail2@domain.com");
                    emailService.AddTo("Name3", "mail3@domaincom");
    
                    emailService.AddAttachment(filename", stream);
                    await emailService.SendAsync(msg);
    
                    // Or use it from UserManager
                    (UserManager.EmailService as EmailService).AddAttachment("name", yourStream);
                    await UserManager.SendEmailAsync("userid", "subject", "body");
