    message.Subject = "Email Subject";
    message.From = from;
    message.To.Add(to);
    message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString("<html><head></head><body><h1>Hello World!</h1></body></html>", null, MediaTypeNames.Text.Html));
    message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString("Hello World!", null, MediaTypeNames.Text.Plain));
    await smtpClient.SendMailAsync(message);
