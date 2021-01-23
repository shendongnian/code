    public void SendEmail(string htmlBody, string email, string emailBody, string subject)
    {
      PdfDocument doc = null;
      
      try
      {
        //Reading the html and converting it to Pdf
        HtmlToPdf pdf = new HtmlToPdf();
        PdfDocument doc = pdf.ConvertHtmlString(htmlBodyReservaPasajeros);
        
        using (MemoryStream memoryStream = new MemoryStream())
        { 
          doc.Save(memoryStream);
          byte[] bytes = memoryStream.ToArray();
          
          memoryStream.Close();
          
          MailMessage message= new MailMessage();
          message.From = new MailAddress(
            ConfigurationManager.AppSettings[url + "Email"]
          );
          message.To.Add(new MailAddress(email));
          message.Subject = subject;
          message.Body = htmlBody;
          message.IsBodyHtml = true;
          message.Attachments.Add(new Attachment(
            new MemoryStream(bytes),
            "Prueba.pdf"
          ));
          //Sending the email
          . . .
        }
        doc.Close(); 
      }            
      catch (Exception e)
      {
        // handle Exception
        . . .
      }
    }
    
