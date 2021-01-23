    private void btnBugEmail_Click(object sender, EventArgs e)
    {
        Cursor.Current = Cursors.WaitCursor;
        try
        {
            SmtpClient client = new SmtpClient("details here");
            MailMessage message = new MailMessage();
            message.From = new MailAddress("email here");
            string mailBox = txtBugAdd.Text.Trim();
            message.To.Add(mailBox);
            string mailFrom = txtEmailFromBug.Text.Trim();
            message.CC.Add(mailFrom);
            string mailCC = txtMailCCBug.Text.Trim();
            message.Bcc.Add(mailCC);
            message.IsBodyHtml = true;
            message.Body = "Bug Report - please see below: " +
                "\n" + "<br>" + "<b>" + "1. What were you doing at the time of the error?" + "</b>" +
                    "\n" + "<br>" + rtbTimeOfError.Text +
                    "\n" + "<br>" + "<b>" + "2. Are you able to repeat the steps and achieve the same error?" + "</b>" +
                    "\n" + "<br>" + rtbCanRepeat.Text +
                    "\n" + "<br>" + "<b>" + "3. Does this problem happen again if you change any of the details you have entered?" + "</b>" +
                    "\n" + "<br>" + rtbChangeDetails.Text;
            message.Subject = "Bug Report";
            var image = pboxBugImage.Image;
            var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            
            message.Attachments.Add(new Attachment(ms, MediaTypeNames.Application.Octet));            
            client.Credentials = new System.Net.NetworkCredential("credentials here");
            client.Port = System.Convert.ToInt32(25);
            client.Send(message);
            new Endpage().Show();
            this.Close();
        }
        catch
        {
            MessageBox.Show("my comment here");
        }
    }
