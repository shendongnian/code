     MailMessage msg = new MailMessage("noreply@test.com", "manager@test.com", "Notification For Lead / Admin ",
                 "Emp Name :" + EmpName);
                msg.Body = "Emp Name : " + EmpName + "<br /><br >" + Environment.NewLine + timsheetMail;             
    
                msg.IsBodyHtml = true;
                
    	    msg.CC.Add(toMail); msg.CC.Add(admin);
                SmtpClient SMTPServer = new SmtpClient("mail.myserver.com", 25);
                SMTPServer.Timeout = 300000;
                SMTPServer.EnableSsl = false;
                SMTPServer.Credentials = new System.Net.NetworkCredential("noreply@test.com", "passw0rd");
                SMTPServer.Send(mailObj);
