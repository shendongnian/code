     try
            {
                MailMessage Msg = new MailMessage();
                // Sender e-mail address.
                Msg.From = new MailAddress(txtUsername.Text);
                // Recipient e-mail address.
                Msg.To.Add(txtTo.Text);
                Msg.Subject = txtSubject.Text;
                // File Upload path
                if (fileUpload1.HasFile)
                {
                    // Create HTML view
                    string mailbody = txtBody.Text + "<br/><img src=cid:companylogo>";
                    AlternateView htmlMail = AlternateView.CreateAlternateViewFromString(mailbody, null, "text/html");
                    String FileName = fileUpload1.PostedFile.FileName;
                    LinkedResource myimage = new LinkedResource(FileName);
                    myimage.ContentId = "companylogo";
                    htmlMail.LinkedResources.Add(myimage);
                    Msg.AlternateViews.Add(htmlMail);
                }
               
                // your remote SMTP server IP.
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential(txtUsername.Text, txtpwd.Text);
                smtp.EnableSsl = true;
                smtp.Send(Msg);
                Msg = null;
                Page.ClientScript.RegisterStartupScript(GetType(), "UserMsg", "<script>alert('Mail sent thank you...');if(alert){ window.location='SendMail.aspx';}</script>", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }`
