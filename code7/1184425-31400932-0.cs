    using System;
    using System.Net.Mail;
    using System.IO;
    
     protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage Msg = new MailMessage();
                // Sender e-mail address.
                Msg.From = new MailAddress(txtUsername.Text);
                // Recipient e-mail address.
                Msg.To.Add(txtTo.Text);
                Msg.Subject = txtSubject.Text;
                // File Upload path
                String FileName = fileUpload1.PostedFile.FileName;
                string mailbody = txtBody.Text + "<br/><img          src=cid:companylogo>";
                string fileName = Path.GetFileName(FileName);
                Msg.Attachments.Add(new Attachment(fileUpload1.PostedFile.InputStream, fileName));
                //LinkedResource myimage = new LinkedResource(FileName);
                // Create HTML view
                AlternateView htmlMail = AlternateView.CreateAlternateViewFromString(mailbody, null, "text/html");
                // Set ContentId property. Value of ContentId property must be the same as
                // the src attribute of image tag in email body. 
                //myimage.ContentId = "companylogo";
               // htmlMail.LinkedResources.Add(myimage);
                Msg.AlternateViews.Add(htmlMail);
                // your remote SMTP server IP.
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential(txtUsername.Text, txtpwd.Text);
                smtp.EnableSsl = true;
                smtp.Send(Msg);
       
                Msg = null;
                //ClientScript.RegisterStartupScript( "<script>alert('Mail sent thank you...');if(alert){ window.location='SendMail.aspx';}</script>");
                Response.Write("<script>alert('Email Sent');</script>"); 
    
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Unable To Send Email');</script>"); 
                Console.WriteLine("{0} Exception caught.", ex);
            }
        }
