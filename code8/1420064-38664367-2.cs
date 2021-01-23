      MailMessage msg = new MailMessage();
      msg.From = new MailAddress("<from>");
      msg.To.Add(new MailAddress("<to>"));
      msg.Subject = "test s/mime";
      
      MemoryStream ms = new MemoryStream(signedbytes);
      AlternateView av = new AlternateView(ms, "application/pkcs7-mime; smime-type=signed-data;name=smime.p7m");
      msg.AlternateViews.Add(av);
