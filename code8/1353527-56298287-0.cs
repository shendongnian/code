    services.AddDecoratorScoped<IEmailMessageSender, EmailMessageSenderWithRetryDecorator>(
        childServices =>
        {
           childServices.AddScoped<IEmailMessageSender, SmtpEmailMessageSender>();
        });
    
  
