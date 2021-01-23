    [WebMethod]
    public String SendMailWithAttachment(string mail_sender, string[] mail_receiver, string mail_subject, string mail_text, byte[] attachment_data, string attachment_name){
       using(var ms = new MemoryStream(attachment_data)){
           var attachment = new System.Net.Mail.Attachment(ms,attachment_name);
           ...
       }
    }
