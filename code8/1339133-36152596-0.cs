    protected void btnEmail_Click(object sender, EventArgs e)
        { 
            vr txtmsg = "hello";
            var ToMail ="someone@some.com";
            using (MailMessage mm = new MailMessage(txtmsg , ToMail ))
            {
                mm.Subject ="Comments";
                mm.Body = "body text";
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "yourhost";
                smtp.EnableSsl = true;
                //Provide those
                NetworkCredential NetworkCred = new NetworkCredential("username","pass");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                Response.Write("<script>alert('Mail Sent')</script>");
            }
        }
