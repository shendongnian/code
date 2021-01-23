            ExtendedPropertyDefinition PidTagInternetMessageId = new ExtendedPropertyDefinition(4149, MapiPropertyType.String);
            EmailMessage ema = new EmailMessage(service);
            ema.Subject ="test from ews";
            ema.Body = new MessageBody("test<br>Rgds<>");
            ema.ToRecipients.Add("gscales@domain.com");
            ema.SetExtendedProperty(PidTagInternetMessageId,("<" +Guid.NewGuid().ToString() + "@domain.com>"));
            ema.SendAndSaveCopy();
