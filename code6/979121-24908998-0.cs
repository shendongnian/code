    var message = new MimeMessage ();
    message.From.Add (new MailboxAddress ("Joey", "joey@friends.com"));
    message.To.Add (new MailboxAddress ("Alice", "alice@wonderland.com"));
    message.Subject = "How you doin?";
    
    var builder = new BodyBuilder ();
    
    // Set the plain-text version of the message text
    builder.TextBody = @"Hey Alice,
    
    What are you up to this weekend? Monica is throwing one of her parties on
    Saturday and I was hoping you could make it.
    
    Will you be my +1?
    
    -- Joey
    ";
    
    // Add an attachment
    builder.Attachments.Add (file);
    
    var attachment = builder.Attachments[0];
    
    // setting the attachment.FileName will set the Content-Disposition's filename
    // parameter as well as the Content-Type's name parameter.
    attachment.FileName = "история-болезни.doc";
    
    // FWIW, very few, if any, mail clients actually care about these fields...
    // they are optional and can be ignored.
    //var disposition = attachment.ContentDisposition;
    //disposition.CreationDate = File.GetCreationTime (file);
    //disposition.ModificationDate = File.GetLastWriteTime (file);
    //disposition.ReadDate = File.GetLastAccessTime (file);
    //disposition.Size = new FileInfo (file).Length;
    
    // Now we just need to set the message body and we're done
    message.Body = builder.ToMessageBody ();
    
    // Now send via MailKit's SmtpClient
    smtpClient.Send (message);
